using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroRotate : MonoBehaviour 
{

    private void Start() {
        Input.gyro.enabled = true;
    }


    private void Update() {

        transform.Rotate(-Input.gyro.rotationRateUnbiased.x, -Input.gyro.rotationRateUnbiased.z, -Input.gyro.rotationRateUnbiased.y);
    }
}
