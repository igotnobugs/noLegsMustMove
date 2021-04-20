using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class MoveFrontOfHero : StateMachineBehaviour {

    public Vector3 offsetFocus;
    public float speed;
    //public bool look = false;

    private Transform targetFocus;
    private Transform gameObjectTransform;
    private Vector3 targetPosition;
    private PositionConstraint positionConstraint;
    private CameraControl cameraControl;
    private AimConstraint aimConstraint;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        cameraControl = animator.GetComponent<CameraControl>();
        targetFocus = cameraControl.targetFocus;
        positionConstraint = animator.GetComponent<PositionConstraint>();
        aimConstraint = animator.GetComponent<AimConstraint>();
        positionConstraint.constraintActive = false;
        gameObjectTransform = animator.gameObject.transform;
        targetPosition = targetFocus.position + offsetFocus;

    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        gameObjectTransform.position = Vector3.Lerp(gameObjectTransform.position,
            targetPosition, speed);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        aimConstraint.constraintActive = false;
    }
}
