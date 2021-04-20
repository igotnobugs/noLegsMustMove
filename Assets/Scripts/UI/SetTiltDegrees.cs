using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTiltDegrees : MonoBehaviour 
{
    public TiltWorld tiltWorld;
    public Text textPower;

    private void Start() {
        
    }


    private void Update() {
        textPower.text = tiltWorld.rollLimit.ToString("##") + " Deg";
    }
}
