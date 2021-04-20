using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTiltPower : MonoBehaviour {

    public float powerAdd = 2.0f; 

    private void Start() {

    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            GyroRotate gyro = FindObjectOfType<GyroRotate>();
            

            TiltWorld tiltWorld = FindObjectOfType<TiltWorld>();
            tiltWorld.AddTiltPower(powerAdd);
            Destroy(gameObject, 0.0f);
        }
    }
}
