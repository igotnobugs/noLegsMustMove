using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltWorld : MonoBehaviour 
{

    public float rollLimit; // X
    public float pitchLimit; // Z

    public Transform targetDummy;
    public float speed;

    private void Start() {

    }


    private void LateUpdate() {
        float eulerx = targetDummy.rotation.eulerAngles.x;
        float eulerz = targetDummy.rotation.eulerAngles.z;

        if (eulerx > 180)
            eulerx -= 360;
        if (eulerz > 180)
            eulerz -= 360;


        float angleX = Mathf.Clamp(eulerx, -rollLimit, rollLimit);
        float angleZ = Mathf.Clamp(eulerz, -pitchLimit, pitchLimit);
        

        Quaternion newRotation = Quaternion.Euler(angleX, 0, angleZ);

        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, speed);
        //transform.rotation = newRotation;
    }

    public void AddTiltPower(float amount) {
        rollLimit += amount;
        pitchLimit += amount;
        Debug.Log(amount + " degrees added.");
    }
}
