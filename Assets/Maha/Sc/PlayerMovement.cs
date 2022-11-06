using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables
    [SerializeField] private float Speed;
    [SerializeField] private Transform cameraReference;
    private Rigidbody rb;
    private float facing;
    private Animator anim;
    #endregion

    #region Methods
     
    private void Start()
    {
      
        rb = GetComponent<Rigidbody>();
        anim= GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {

        float xMovement = Input.GetAxis("Horizontal") * Speed;
        float zMovement = Input.GetAxis("Vertical") * Speed;
        Vector3 movement = new Vector3(xMovement, 0, zMovement);
        movement = cameraReference.TransformDirection(movement);
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
 
        if (movement.x != 0 || movement.z != 0)
        {
            anim.SetBool("canwalk", true);
       
            facing = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
        }
        else 
        {
            anim.SetBool("canwalk", true);

        }
  
        rb.rotation = Quaternion.Euler(0, facing, 0);
        cameraReference.eulerAngles = new Vector3(0, cameraReference.eulerAngles.y, 0);
    }
    #endregion
}