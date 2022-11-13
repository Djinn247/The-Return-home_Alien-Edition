using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSecurityAI : MonoBehaviour
{
    [Header("Security Wait Settings")]
    [SerializeField] private float minWaitTime = 2.5f;
    [SerializeField] private float maxWaitTime = 4.0f;

    [Header("Security Wander Settings")]
    [SerializeField] private float minWanderTime = 5f;
    [SerializeField] private float maxWanderTime = 10f;

    [SerializeField] private float minRotationDistance = 30f;
    [SerializeField] private float MaxRotationDistance = 330f;

    [SerializeField] private float minDistance = 10f;
    [SerializeField] private float maxDistance = 30f;

    [Header("Security Chase Settings")]
    [SerializeField] private float PlayerStartChaseDistance = 10f;
    [SerializeField] private float PlayerStopChaseDistance = 20f;

    [Header("Security Attack Settings")]
    [SerializeField] private float startAttackDistance = 3f;
    [SerializeField] private float stopAttackDistance = 5f;
    [SerializeField] private float attackCooldown = 1.5f;



    public enum SecurityState
    {
        Wait,
        Wander,
        Chase,
        Attack,
    }

    private SecurityState securityState = SecurityState.Wait;

    [SerializeField] private bool isWaiting = false;
    private Coroutine waitingCoroutine;

    [SerializeField] private bool isWandering = false;
    private Coroutine wanderingCoroutine;

    private ZombieMovement zombieMovement;

    private Transform PlayerTransform;
    private bool isChasing = false;

    private bool canAttack = true;


    private bool isShot = false;

    private void Start()
    {


        zombieMovement = GetComponent<ZombieMovement>();
        PlayerTransform = GameObject.FindWithTag("Player").transform;

        //wanderingCoroutine = StartCoroutine(WalkTime()); 
        //waitingCoroutine = StartCoroutine(GoWandering());
    }




    private void Update()
    {
        switch (securityState)
        {

            case SecurityState.Wait:
                if (ChasePlayer())
                {
                    IntChase();
                }
                ZombieWait();
                break;
            case SecurityState.Wander:
                if (ChasePlayer())
                {
                    IntChase();
                }
                ZombieWander();
                break;
            case SecurityState.Chase:

                if (playerDistance <= startAttackDistance)
                {

                    zombieMovement.IsMoving = false;
                    securityState = SecurityState.Attack;

                }
                ZombieChase();
                break;
            case SecurityState.Attack:
                ZombieAttack();
                break;
            default:
                break;

        }
    }

    private Vector3 Playerposition
    {
        get { return PlayerTransform.position; }
    }

    private float playerDistance
    {
        get { return Vector3.Distance(transform.position, Playerposition); }
    }

    //if the zombie is shot then destroy the zombie (unreachable code)
    private void Death()
    {
        if (isShot)
        {
            Destroy(gameObject);
        }
    }

    private bool ChasePlayer()
    {
        if (isChasing)
        {

            if (playerDistance <= PlayerStopChaseDistance)
            {
                return true;
            }
            else
            {
                isChasing = false;
                return false;
            }

        }
        else
        {
            if (playerDistance <= PlayerStartChaseDistance)
            {
                isChasing = true;
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    private void IntChase()
    {
        //   StopCoroutine(wanderingCoroutine);
        //   StopCoroutine(waitingCoroutine);
        isWaiting = false;
        isWandering = false;
        zombieMovement.IsMoving = true;
        securityState = SecurityState.Chase;

    }

    private void ZombieWait()
    {

        if (!isWaiting)
        {
            waitingCoroutine = StartCoroutine(GoWandering());
        }

    }

    IEnumerator GoWandering()
    {
        isWaiting = true;
        yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
        securityState = SecurityState.Wander;
        isWaiting = false;

    }

    private void ZombieWander()
    {

        if (!isWandering)
        {
            isWandering = true;

            float currentx = transform.position.x;
            float currentz = transform.position.z;

            float targetx = currentx + Random.Range(minDistance, maxDistance);
            float targetz = currentz + Random.Range(minDistance, maxDistance);

            float targetY = Terrain.activeTerrain.SampleHeight(new Vector3(targetx, 0f, targetz));
            zombieMovement.SetDestination(new Vector3(targetx, targetY, targetz));

            if (zombieMovement.hasArrived && isWandering)
            {
                isWandering = false;

                if (zombieMovement.distance <= 1)
                {

                    zombieMovement.hasArrived = true;

                }
                else if (zombieMovement.distance > 1)
                {

                    zombieMovement.hasArrived = false;

                }

                securityState = SecurityState.Wait;
            }




            //transform.Rotate(0f,Random.Range(minRotationDistance,MaxRotationDistance),0f);
            //wanderingCoroutine = StartCoroutine(WalkTime());

        }

    }

    IEnumerator WalkTime()
    {
        zombieMovement.IsMoving = true;
        yield return new WaitForSeconds(Random.Range(minWanderTime, maxWanderTime));
        zombieMovement.IsMoving = false;
        isWaiting = false;
        securityState = SecurityState.Wait;
        isWandering = false;
    }

    private void ZombieChase()
    {

        if (ChasePlayer())
        {
            transform.LookAt(PlayerTransform);
            zombieMovement.SetDestination(Playerposition);
        }
        else
        {
            // zombieMovement.IsMoving = false;

            zombieMovement.SetDestination(transform.position);
            securityState = SecurityState.Wait;


        }


    }

    private void ZombieAttack()
    {

        if (canAttack)
        {
            //attack code!!
            Debug.Log("attacked the player");

            StartCoroutine(AttackCooldown());
        }
        else
        {

            if (playerDistance > stopAttackDistance)
            {
                IntChase();
            }


        }

    }

    IEnumerator AttackCooldown()
    {

        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;

    }
}
