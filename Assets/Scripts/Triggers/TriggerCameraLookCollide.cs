using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

//Add a source to Position Constrait to the camera

public class TriggerCameraLookCollide : MonoBehaviour 
{
    public Transform transformToLook;
    public float lookWeight = 0.25f;
    public float lookTime = 5.0f;

    private Camera mainCamera;
    private int sourceIndex;
    private bool isTriggered = false;
    private ConstraintSource source;

    private void Start() {
        mainCamera = Camera.main;

        source = new ConstraintSource {
            sourceTransform = transformToLook,
            weight = lookWeight
        };
    }


    private void OnTriggerEnter(Collider other) {
        if (isTriggered) return;
        if (other.tag != "Player") return;
        if (transformToLook == null) return;
        
        isTriggered = true;

        sourceIndex = mainCamera.GetComponent<PositionConstraint>().AddSource(source);

        Destroy(this, lookTime);
    }

    private void OnDestroy() {
        mainCamera.GetComponent<PositionConstraint>().RemoveSource(sourceIndex);
    }

}
