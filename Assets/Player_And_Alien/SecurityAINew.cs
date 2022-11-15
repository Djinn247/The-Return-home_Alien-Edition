using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SecurityAINew : MonoBehaviour
{
    [SerializeField] private Transform[] paths;
    [SerializeField] private Transform playerposition;

    private Animator anim;

    private float playerDistance;
    private float facing;
    private Rigidbody rb;

    private NavMeshAgent securityGuard;
    private bool waiting = false;
    private bool playerSeen = false;
    private int currentTarget = 0;

    private void Start()
    {

        rb = GetComponent<Rigidbody>();

        anim = GetComponent<Animator>();

        securityGuard = GetComponent<NavMeshAgent>();
        securityGuard.SetDestination(paths[currentTarget].position);
    }

    private void Update()
    {
        float distanceFrom = Vector3.Distance(transform.position, securityGuard.destination);
        

        if (!playerSeen)
        {
            if (distanceFrom < 1 && !waiting)
            {
                StartCoroutine("Wait");
            }
        }

        playerDistance = Vector3.Distance(transform.position, playerposition.position);

        if (playerDistance < 3f)
        {
            facing = Mathf.Atan2(playerposition.position.x - transform.position.x, playerposition.position.z - transform.position.z) * Mathf.Rad2Deg;
            playerSeen = true;
        }
        else
        {
            facing = Mathf.Atan2(paths[currentTarget].position.x - transform.position.x, paths[currentTarget].position.z - transform.position.z) * Mathf.Rad2Deg;
            playerSeen = false;
        }

        if (playerDistance <=0)
        {
            anim.SetBool("wait", true);
            anim.SetBool("walk", false);
        }
        else{
            anim.SetBool("walk", true);
            anim.SetBool("wait", false);
        }

        rb.rotation = Quaternion.Euler(0, facing, 0);
    }

    private IEnumerator Wait()
    {
        waiting = true;
        
        yield return new WaitForSeconds(3);
        if (currentTarget == 3)
            currentTarget = 0;
        else
            currentTarget++;
        securityGuard.SetDestination(paths[currentTarget].position);
        waiting = false;
       

    }
}