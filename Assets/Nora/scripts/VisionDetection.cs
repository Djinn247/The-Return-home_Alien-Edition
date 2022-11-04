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
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
            player = other.gameObject;
            print("player entered");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
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
                print(hit.collider +"    " +hit.collider.gameObject.name);
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    print("player seen");
                    if (player.GetComponent<AlienState>().currentState == AlienState.PlayerState.HumanState)
                    {
                        //TODO Sus meter
                        print("player seen as human");
                        if(sus<100)
                            sus += 1 / Vector3.Distance(transform.position, player.transform.position);
                        susbarscript.suspercentage = (sus * 0.01f);
                    }
                }
            }
        }
        if (sus > 100)
            sus = 100;
    }

   
}
