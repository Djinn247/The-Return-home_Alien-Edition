using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienState : MonoBehaviour
{

    //private PlayerMovement movementScript;
    public PlayerState currentState;
    public float susORnot = 1;
    [SerializeField] Morph MorphingScript;

    //define player states 
    public enum PlayerState
    {
        AlienState,
        HumanState
        //HidingState
    }

    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    {
        //for testing 
        /*
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SetToAlienState();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            SetToHumanState();
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            SetToHidingState();


        }*/

    }


    void setCurrentState(PlayerState state)
    {
        currentState = state;

    }

    public void SetToHumanState()
    {
        setCurrentState(PlayerState.HumanState);
        susORnot = 2;

        MorphingScript.modelA.SetActive(true);
        MorphingScript.isModelA = true;
        MorphingScript.modelB.SetActive(false);

        //modelA setactive = true
        //modelB setactive = false
    }

    public void SetToAlienState()
    {
        setCurrentState(PlayerState.AlienState);
        susORnot = 1;

        MorphingScript.modelA.SetActive(false);
        MorphingScript.modelB.SetActive(true);
        MorphingScript.modelNumber = 2;
        MorphingScript.isModelA = false;

        //modelA setactive = false
        //modelB setactive = true

    }




}
