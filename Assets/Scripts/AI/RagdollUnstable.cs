using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollUnstable : MonoBehaviour 
{
    public Animator animator;
    public Transform floor;
    public Transform reference;

    public float recoveryTime = 2.0f;

    [Min(0)] public float instabillity;

    private float time;
    public bool tripped = false;

    private void Update() {
        float angle = Vector3.Angle(reference.up, floor.up);
    
        if (time > 0) {
            time -= Time.deltaTime;
        }

        if (instabillity < angle) {
            animator.enabled = false;
            tripped = true;
            recoveryTime = time;
        } else {
            if (time <= 0) {
                animator.enabled = true;
                tripped = false;
            }
        }

    }

    public bool IsTripped() {
        return tripped;
    }

}
