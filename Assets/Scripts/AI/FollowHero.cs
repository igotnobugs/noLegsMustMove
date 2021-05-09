using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowHero : MonoBehaviour 
{
    public float range = 10;
    public Transform target;

    private NavMeshAgent agent;
    private RagdollUnstable ragdollState;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        ragdollState = GetComponent<RagdollUnstable>();
    }


    private void LateUpdate() {

        if (ragdollState.IsTripped()) {
            agent.isStopped = true;
            return;
        } else {
            agent.isStopped = false;
        }

        if (Vector3.Distance(transform.position, target.position) < range) {
            agent.isStopped = false;
            agent.destination = target.position;
        } else {
            agent.isStopped = true;
        }

    }

    public void StopAgent(bool status) {
        agent.isStopped = status;
    }
}
