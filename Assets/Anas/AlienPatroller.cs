using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AlienPatroller : MonoBehaviour
{
    [SerializeField] private NavMeshAgent mNavMeshAgent;
    [SerializeField] private Transform[] patrolWaypoints;
    private int currentIndex = 0;

    private void Start()
    {
        if (mNavMeshAgent == null)
        {
            mNavMeshAgent = GetComponentInChildren<NavMeshAgent>();
        }
        Invoke("Patrol", 1f);
    }

    private void Update()
    {
        if (!mNavMeshAgent.pathPending)
        {
            if (mNavMeshAgent.remainingDistance <= mNavMeshAgent.stoppingDistance)
            {
                if (!mNavMeshAgent.hasPath || mNavMeshAgent.velocity.sqrMagnitude == 0f)
                {
                    Invoke("Patrol", 5f);
                }
            }
        }
    }

    private void Patrol()
    {
        //TODO pathing
    }
}
