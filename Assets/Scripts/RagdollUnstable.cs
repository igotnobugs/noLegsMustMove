using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollUnstable : MonoBehaviour 
{
    public Animator animator;
    public Transform floor;
    public Transform reference;

    [Min(0)] public float instabillity;


    private void Start() {
        
    }


    private void Update() {
        float angle = Vector3.Angle(reference.up, floor.up);
    
        if (instabillity < angle) {
            animator.enabled = false;
        } else {
            animator.enabled = true;
        }

    }


}
