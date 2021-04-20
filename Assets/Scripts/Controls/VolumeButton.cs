using UnityEngine;
using System.Collections.Generic;

public interface IVolumeListener {
    void OnVolumeUp();
    void OnVolumeDown();
}

public abstract class VolumeListenerGO : MonoBehaviour, IVolumeListener {
    public abstract void OnVolumeUp();
    public abstract void OnVolumeDown();
}


public class VolumeButton : MonoBehaviour {

    public bool m_bGetVolumeFromPhone = true;
    //for non gameobject listener
    public List<IVolumeListener> m_vVolumeListener = null;
    //for gameobject listener (easier to edit in scene mode)
    public VolumeListenerGO[] m_vVolumeListenerGO = null;

    private float m_fPrevVolume = -1;
    private bool m_bShutDown = false;

    //quick access to reference
    private static VolumeButton s_instance = null;


    public static VolumeButton Get() {
        return s_instance;
    }

    //Get phone volume if running or android or application volume if running on pc
    //(or wanted by user)
    public float GetVolume() {
        if (m_bGetVolumeFromPhone && Common.IsRunningOnAndroid()) {
            AndroidJavaObject audioManager = Common.GetAndroidAudioManager();
            return audioManager.Call<int>("getStreamVolume", 3);
        }
        else {
            return AudioListener.volume;
        }

    }

    //set phone or application volume (according if running on android or if user want application volume)
    public void SetVolume(float a_fVolume) {
        if (m_bGetVolumeFromPhone && Common.IsRunningOnAndroid()) {
            AndroidJavaObject audioManager = Common.GetAndroidAudioManager();
            audioManager.Call("setStreamVolume", 3, (int)a_fVolume, 0);
        }
        else {
            AudioListener.volume = a_fVolume;
        }
    }

    private void ResetVolume() {
        SetVolume(m_fPrevVolume);
    }

    void Start() {
        s_instance = this;
        PowerOn();
    }

    void OnVolumeDown() {
        if (m_vVolumeListener != null) {
            foreach (IVolumeListener listener in m_vVolumeListener) {
                listener.OnVolumeDown();
            }
        }
        if (m_vVolumeListenerGO != null) {
            foreach (IVolumeListener listener in m_vVolumeListenerGO) {
                listener.OnVolumeDown();
            }
        }
    }

    void OnVolumeUp() {
        if (m_vVolumeListener != null) {
            foreach (IVolumeListener listener in m_vVolumeListener) {
                listener.OnVolumeUp();
            }
        }
        if (m_vVolumeListenerGO != null) {
            foreach (IVolumeListener listener in m_vVolumeListenerGO) {
                listener.OnVolumeUp();
            }
        }

    }

    //If user want to change volume, he has to mute this script first
    //else the script will interpret this has a user input and resetvolume
    public void ShutDown() {
        m_bShutDown = true;
    }

    //to unmute the script
    public void PowerOn() {
        m_bShutDown = false;
        //get the volume to avoid interpretating previous change (when script was muted) as user input
        m_fPrevVolume = GetVolume();
    }

    // Update is called once per frame
    void Update() {
        if (m_bShutDown)
            return;

        float fCurrentVolume = GetVolume();
        float fDiff = fCurrentVolume - m_fPrevVolume;

        //if volume change, compute the difference and call listener according to
        if (fDiff < 0) {
            ResetVolume();
            OnVolumeDown();
        }
        else if (fDiff > 0) {
            ResetVolume();
            OnVolumeUp();
        }
    }

}