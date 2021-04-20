using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CameraAnimationState : StateMachineBehaviour
{   
    public Vector3 offsetFocus;
    public float speed;
    public bool lookDown = false;

    private Transform targetFocus;
    private Transform gameObjectTransform;
    private Vector3 targetPosition;
    private PositionConstraint positionConstraint;
    private CameraControl cameraControl;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        cameraControl = animator.GetComponent<CameraControl>();
        targetFocus = cameraControl.targetFocus;
        positionConstraint = animator.GetComponent<PositionConstraint>();
        positionConstraint.constraintActive = false;
        gameObjectTransform = animator.gameObject.transform;
        targetPosition = targetFocus.position + offsetFocus;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        gameObjectTransform.position = Vector3.Lerp(gameObjectTransform.position, 
            targetPosition, speed);
        if (lookDown) {
            gameObjectTransform.rotation = Quaternion.Lerp(gameObjectTransform.rotation,
                cameraControl.lookDownGround.rotation, speed);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

}
