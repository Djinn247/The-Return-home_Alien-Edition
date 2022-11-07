using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables
    // How fast the Player will move
    public float playerSpeed = 2;

    // This should be an empty child of the camera, and is the Transform we will be using to update our Player's directional movement
    [SerializeField] public Transform cameraReference;

    // The Player's Rigidbody Component
    private Rigidbody rb;

    // The value we will be using to determine which direction the player faces while moving
    private float facing;
    private Animator anim;
    #endregion

    #region Methods
    // Start is called before the first frame update
    private void Start()
    {
        // Directly grabs the Player's Rigidbody Component
        rb = GetComponent<Rigidbody>();
        anim= GetComponent<Animator>();



    }

    // Update is called once per frame
    private void Update()
    {
        // Creates float values out of our inputs multiplied by the amount of speed we set
        float xMovement = Input.GetAxis("Horizontal") * playerSpeed;
        float zMovement = Input.GetAxis("Vertical") * playerSpeed;
    

        // Vector3 values made up of our input values
        Vector3 movement = new Vector3(xMovement, 0, zMovement);

        
        movement = cameraReference.TransformDirection(movement);

        // Generates movement in the Player's Rigidbody using the Vector3 values from above
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        // Takes our player's movement to calculate which angle our player should be rotating towards
        if (movement.x != 0 || movement.z != 0)
        {
            anim.SetBool("canwalk", true);
           // anim.SetBool("canrun", false);
            facing = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
        }
        else if (movement.x == 0 || movement.z == 0)
        {
          //  anim.SetBool("canwalk", false);
          //  anim.SetBool("canrun", true);

        }
        // Rotates our player to face in the direction it is moving towards
        rb.rotation = Quaternion.Euler(0, facing, 0);

        // Locks our camera reference's Transform to 0 
        cameraReference.eulerAngles = new Vector3(0, cameraReference.eulerAngles.y, 0);
    }
    #endregion
}