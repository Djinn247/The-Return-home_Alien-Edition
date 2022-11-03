using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionDetection : MonoBehaviour
{
    public bool playerInRange = false;
    [SerializeField] private GameObject eyes;
    [SerializeField] private GameObject player;
    //private string[] visionLayerMask = {"",""};
    [SerializeField] private float sus = 0f;
    [SerializeField] private SusBar susbarscript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HumanAlien"))
        {
            playerInRange = true;
            player = other.gameObject;
            print("player entered");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("HumanAlien"))
        {
            playerInRange = false;
            print("player left");
        }
    }

    private void FixedUpdate()
    {
        if(playerInRange)
        {
            print("player in range");
            RaycastHit hit;
            int defaultMask = 1 << 0;
            int groundMask = 1 << 3;
            if(Physics.Raycast(eyes.transform.position, player.transform.position-eyes.transform.position, out hit, 100f, defaultMask | groundMask))
            {
                print(hit.collider);
                if (hit.collider.gameObject.CompareTag("HumanAlien"))
                {
                    print("player seen");
                    if (player.GetComponent<AlienState>().currentState == AlienState.PlayerState.HumanState)
                    {
                        //TODO Sus meter
                        print("player seen as human");
                       
                        
                    }
                }
            }
        }
    }

    private void Update()
    {
        if (playerInRange)
        {
            sus += 1 / Vector3.Distance(transform.position, player.transform.position);
            susbarscript.suspercentage = (sus * 0.01f);
        }
    }
}
