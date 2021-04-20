using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StabilizeVolumeButton : MonoBehaviour, IVolumeListener 
{
    public float speed = 0.2f;
    public float timeOut = 0.0f;

    public Quaternion restRotation;
    //public GyroRotate gyroRotate;
    private bool isRotating = false;

    private void Start() {
        restRotation = transform.rotation;
    }

    private void Update() {
        if (isRotating) {
            if (timeOut > 1) {
                transform.rotation = Quaternion.Lerp(transform.rotation, restRotation, speed);
                timeOut -= Time.deltaTime;
            }
            else {
                isRotating = false;
                //gyroRotate.ToggleGyro(true);
            }
        }
    }

    public void OnVolumeDown() {
        Debug.Log("volumeDownPressed");
        timeOut = 2.0f;
        isRotating = true;
        //gyroRotate.ToggleGyro(false);
    }

    public void OnVolumeUp() {
        Debug.Log("volumeUpPressed");
    }
}
