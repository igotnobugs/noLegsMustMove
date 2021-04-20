using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraControl : MonoBehaviour 
{
    public Animator animator;
    public Transform targetFocus;
    public Transform lookDownGround;

    private void Start() {
        animator.SetBool("inFrontOfHero", true);
    }

    private void LateUpdate() {
        SeeThrough();
    }

    private void SeeThrough() {
        float distance = Vector3.Distance(transform.position, targetFocus.position);
        if (Physics.Raycast(transform.position, targetFocus.position - transform.position, out RaycastHit hit, distance)) {
            if (hit.collider.tag != "Player") {
                if (hit.collider.TryGetComponent(out RaycastCameraHide mesh)) {
                    mesh.Hide();
                }                
            }
        }
    }
}
