using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienState : MonoBehaviour
{

    //private PlayerMovement movementScript;
    public PlayerState currentState;
    public float susORnot = 1;

    //define player states 
    public enum PlayerState
    {
        AlienState,
        HumanState,
        HidingState
    }

    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SetToAlienState();
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            SetToHumanState();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            SetToHidingState();


        }

    }


    void setCurrentState(PlayerState state)
    {
        currentState = state;

    }

    public void SetToHumanState()
    {
        setCurrentState(PlayerState.HumanState);
        susORnot = 2;
    }

    public void SetToAlienState()
    {
        setCurrentState(PlayerState.AlienState);
        susORnot = 1;
    }

    public void SetToHidingState()
    {
        setCurrentState(PlayerState.HidingState);
        susORnot = 1;
    }


}
