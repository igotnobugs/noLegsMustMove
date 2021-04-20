using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class MoveAboveTheHero : StateMachineBehaviour {

    public Vector3 offsetFocus;
    public Vector3 newPosition;
    public float speed;
    public bool lookDown = false;

    private Transform targetFocus;
    private Transform gameObjectTransform;
    private Vector3 targetPosition;
    private PositionConstraint positionConstraint;
    private CameraControl cameraControl;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        cameraControl = animator.GetComponent<CameraControl>();
        targetFocus = cameraControl.targetFocus;
        positionConstraint = animator.GetComponent<PositionConstraint>();
        positionConstraint.constraintActive = false;
        gameObjectTransform = animator.gameObject.transform;
        targetPosition = targetFocus.position + offsetFocus;

    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        gameObjectTransform.position = Vector3.Lerp(gameObjectTransform.position,
            targetPosition, speed);

        if (lookDown) {
            gameObjectTransform.rotation = Quaternion.Lerp(gameObjectTransform.rotation,
                cameraControl.lookDownGround.rotation, speed);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {     
        ConstraintSource cameraSource = new ConstraintSource {
            sourceTransform = cameraControl.targetFocus.transform,
            weight = 1
        };
        positionConstraint.translationOffset = cameraControl.transform.position - cameraControl.targetFocus.transform.position;
        positionConstraint.AddSource(cameraSource);
        positionConstraint.constraintActive = true;
        positionConstraint.locked = true;
    }
}
