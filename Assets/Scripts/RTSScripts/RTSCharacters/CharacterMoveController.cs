using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMoveController : MonoBehaviour
{
    private NavMeshAgent navmeshAgent;
    public NavMeshAgent NavMeshAgent { get { return (navmeshAgent == null) ? navmeshAgent = GetComponent<NavMeshAgent>() : navmeshAgent; } }
    public bool canMove;
    private Vector3 targetPoint;
    public void Initalize(float maxSpeed)
    {
        NavMeshAgent.speed = maxSpeed;
        NavMeshAgent.stoppingDistance = 0.1f;
        canMove = true;
    }
    public void MoveTarget(Vector3 targetPos)
    {
        if (!canMove)
            return;
        NavMeshAgent.SetDestination(targetPos);
    }
    public bool IsDestinationReached()
    {
        if (NavMeshAgent.stoppingDistance < NavMeshAgent.remainingDistance - 0.1f)
            return false;
        else
            return true;
    }
}
