using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    #region Variables
  
    [SerializeField] private float WALKSpeed;
    [SerializeField] private Transform cameraReference;
    private Rigidbody rb;
    private float facing;
    private Animator anim;
    #endregion

    #region Methods
    // Start is called before the first frame update
    private void Start()
    {
        // Directly grabs the Player's Rigidbody Component
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();



    }

    // Update is called once per frame
    private void Update()
    {
        
        float xMovement = Input.GetAxis("Horizontal") * WALKSpeed;
        float zMovement = Input.GetAxis("Vertical") * WALKSpeed;


 
        Vector3 movement = new Vector3(xMovement, 0, zMovement);
    

        movement = cameraReference.TransformDirection(movement);
        anim.SetFloat("vz", Mathf.Clamp01(movement.magnitude));

        //  anim.SetFloat("vz", Mathf.Clamp01(movement.magnitude)); 


        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        // Takes our player's movement to calculate which angle our player should be rotating towards
        if (movement.x != 0 || movement.z != 0)
        {
           // anim.SetFloat("input_mag", 0.5f);
             anim.SetBool("canwalk", true);
            facing = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
        }
        else 
        {
            anim.SetBool("canwalk", false);

        }
      
      
        rb.rotation = Quaternion.Euler(0, facing, 0);

     
        cameraReference.eulerAngles = new Vector3(0, cameraReference.eulerAngles.y, 0);
    
    #endregion
}



}
