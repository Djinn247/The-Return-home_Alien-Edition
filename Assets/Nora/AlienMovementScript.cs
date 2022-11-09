using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlenMovementScript : MonoBehaviour
{

    private PlayerMovement movementScript;
    public playerState currentState;

    //define player states 
    public enum playerState
    {
        AlienState,
        HumanState,
        HidingState
    }


    //if currentstate == playerstate.AlienState or something
    private void Update()
    {

    }

    void FixedUpdate()
    {
        /*  switch (currentState)
          {
              case playerState.AlienState:
                  setCurrentState(playerState.AlienState);
                  break;
              case playerState.HumanState:
                  setCurrentState(playerState.HumanState);
                  break;
              case playerState.HidingState:
                  setCurrentState(playerState.HidingState);

                  break;

          }
        */
    }

    //define method for setting the state of playerState
    void setCurrentState(playerState state)
    {
        currentState = state;

    }

}
