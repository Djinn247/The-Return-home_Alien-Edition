using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class transformationScript : MonoBehaviour
{
    [SerializeField] private Image TransformBar;
    [SerializeField] AlienState humanORAlienScript;
    

    public bool countISRunning = false;
    public float timeLeft;



    private void Update()
    {
     //Debug.Log(timeLeft);
    }
    private void Countdown()
    {

        timeLeft -= 0.01f;
        TransformBar.fillAmount = timeLeft;
        countISRunning = true;

        if (timeLeft <= 0f)
        {  
            
            humanORAlienScript.SetToHumanState();
            countISRunning = false;
            CancelInvoke("Countdown");
            
        }
    }

    public void CountUp()
    {

        if (timeLeft < 1)
        {
            timeLeft += 1;
            TransformBar.fillAmount = timeLeft;
            humanORAlienScript.SetToAlienState();
            if (countISRunning == false)
            { 
            InvokeRepeating("Countdown", 1, 1);
            }
        }
        

        

    }

}


