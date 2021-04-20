using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowHero : MonoBehaviour 
{
    public float range = 10;
    public Transform target;

    private NavMeshAgent agent;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
    }


    private void LateUpdate() {
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
