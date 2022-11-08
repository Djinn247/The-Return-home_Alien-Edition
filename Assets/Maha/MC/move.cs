using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    #region Variables

    [SerializeField] public float WALKSpeed;
    [SerializeField] private Transform cameraReference;
    [SerializeField] private AlienState alienStateScript;
    private Rigidbody rb;
    private float facing;
    [SerializeField] private Animator animHUMAN;
    [SerializeField] private Animator animALIEN;
    #endregion

    #region Methods
    // Start is called before the first frame update
    private void Start()
    {
        // Directly grabs the Player's Rigidbody Component
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    private void Update()
    {
        float xMovement = Input.GetAxis("Horizontal") * WALKSpeed;
        float zMovement = Input.GetAxis("Vertical") * WALKSpeed;

        Vector3 movement = new Vector3(xMovement, 0, zMovement);

        movement = cameraReference.TransformDirection(movement);
        animHUMAN.SetFloat("vz", Mathf.Clamp01(movement.magnitude));
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        // Takes our player's movement to calculate which angle our player should be rotating towards
        if (movement.x != 0 || movement.z != 0)
        {
            // anim.SetFloat("input_mag", 0.5f);

            if (alienStateScript.currentState == AlienState.PlayerState.AlienState)
            {
                AlienMovement();
            }else if(alienStateScript.currentState == AlienState.PlayerState.HumanState)
            {
                
                HumanMovement();
            }

            facing = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
        }
     
        rb.rotation = Quaternion.Euler(0, facing, 0);


        cameraReference.eulerAngles = new Vector3(0, cameraReference.eulerAngles.y, 0);



        #endregion
    }


    private void AlienMovement()
    {


        if (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)))
        {
            WALKSpeed = 8;

            animALIEN.SetBool("Run", true);
            animALIEN.SetBool("walk", false);

            alienStateScript.susORnot = 2;
            Debug.Log("im runninggg");
        }
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
{
             WALKSpeed = 1;
            animALIEN.SetBool("walk", true);
            animALIEN.SetBool("Run", false);
            alienStateScript.susORnot = 1;
        }

    }

    private void HumanMovement()
    {

        if (Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.DownArrow)|| Input.GetKey(KeyCode.LeftArrow)|| Input.GetKey(KeyCode.RightArrow))
        {
            animHUMAN.SetBool("canwalk", true);
            WALKSpeed = 8;
        }
        else{
            animHUMAN.SetBool("canwalk", false);
        }

        //animation for hiding

        

    }




}
