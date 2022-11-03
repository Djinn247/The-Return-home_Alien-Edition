using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienState : MonoBehaviour
{

    private PlayerMovement movementScript;
    public playerState currentState;
    public float susORnot = 0;

    //define player states 
    public enum playerState
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


    void setCurrentState(playerState state)
    {
        currentState = state;

    }

    public void SetToHumanState()
    {
        setCurrentState(playerState.HumanState);
        susORnot = 2;
    }

    public void SetToAlienState()
    {
        setCurrentState(playerState.AlienState);
        susORnot = 1;
    }

    public void SetToHidingState()
    {
        setCurrentState(playerState.HidingState);
        susORnot = 1;
    }


}
