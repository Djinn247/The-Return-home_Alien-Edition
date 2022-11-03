using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AlienPatroller : MonoBehaviour
{
    [SerializeField] private NavMeshAgent mNavMeshAgent;
    [SerializeField] private Transform[] patrolWaypoints;
    private int currentIndex = 0;
    private bool invoked = false;

    private void Start()
    {
        //check if unset and try setting it
        if (mNavMeshAgent == null)
        {
            mNavMeshAgent = GetComponentInChildren<NavMeshAgent>();
        }
        
        //start patrolling
        Invoke("Patrol", 1f);
    }

    private void Update()
    {
        //if nav has no path calculating
        if (!mNavMeshAgent.pathPending)
        {
            //if nav reached the stopping distance
            if (mNavMeshAgent.remainingDistance <= mNavMeshAgent.stoppingDistance)
            {
                //if stopped moving or has no path
                if (!mNavMeshAgent.hasPath || mNavMeshAgent.velocity.sqrMagnitude == 0f)
                {
                    //only invoke once
                    if (!invoked)
                    {
                        invoked = true;
                        Invoke("Patrol", 5f);
                    }
                }
            }
        }
    }

    private void Patrol()
    {
        //set new destination from list of waypoints
        mNavMeshAgent.SetDestination(patrolWaypoints[currentIndex].position);

        //move index for next destination in list
        currentIndex++;
        
        //loop list of waypoints
        if (currentIndex == patrolWaypoints.Length)
            currentIndex = 0;
        
        //reset bool of invoke for next activation
        invoked = false;
    }
}
