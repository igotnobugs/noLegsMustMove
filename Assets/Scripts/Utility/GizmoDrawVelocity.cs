using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoDrawVelocity : MonoBehaviour 
{
    public float rayLength = 3.0f;

    private Rigidbody rb;


    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void OnDrawGizmos() {
        if (rb == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, rb.velocity.normalized * rayLength);
    }
}
