using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoDrawWorldDirection : MonoBehaviour 
{
    public float rayLength = 3.0f;
    public Transform world;
    private void Start() {
        
    }


    private void Update() {
        
    }

    private void OnDrawGizmos() {
        if (world == null) return;
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, world.eulerAngles.normalized * rayLength);
    }
}
