using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMovementScript : MonoBehaviour
{

    private PlayerMovement movementScript;

    //define player states 
    public enum playerState
    {
        AlienState,
        HumanState,
        HidingState
    }

    public playerState currentState;
    //if currentstate == playerstate.AlienState or something
   


    // Use this for initialization
    void Start()
    {
        setCurrentState(playerState.AlienState); //call function to set state to idle
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (currentState)
        {
            case playerState.AlienState:
               // playerStateIdle();
                break;
            case playerState.HumanState:

                break;
            case playerState.HidingState:

                break;

        }

    }




    //define method for setting the state of playerState
    void setCurrentState(playerState state)
    {
        currentState = state;

    }

    public void switchtoAlienState()
    {

       

    }
    

    public void switchtoHumanState()
    {
        movementScript.WALKSpeed = 2;

    }

    public void switchtoHidingState()
    {

    }

}
