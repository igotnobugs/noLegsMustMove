using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroRotate : MonoBehaviour 
{
    Quaternion referenceRotation;

    private void Start() {
        Input.simulateMouseWithTouches = true;
        Input.gyro.enabled = true;
        Screen.orientation = ScreenOrientation.Landscape;
        referenceRotation = Quaternion.Inverse(Input.gyro.attitude);
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {          
            referenceRotation = Quaternion.Inverse(Input.gyro.attitude);
        }

        var raw = Input.gyro.attitude;

        var rot = referenceRotation * raw;
        var euler = rot.eulerAngles;

        var eulerSwitch = Quaternion.Euler(-euler.x, 0, -euler.y);

        transform.rotation = eulerSwitch;
    }
}
