using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class transformationScript : MonoBehaviour
{
    [SerializeField] private Image TransformBar;
    //[SerializeField] private GameObject modelA;
    //[SerializeField] private GameObject modelB;
    [SerializeField] AlienState humanORAlienScript;
    [SerializeField] Move moveScript;
    [SerializeField] Morph MorphingScript;
    private bool meterIsDone = false;
    public float timeLeft;



    private void Update()
    {


     Debug.Log(timeLeft);

    }
    private void Countdown()
    {
        timeLeft -= 0.1f;
        TransformBar.fillAmount = timeLeft;

        if (timeLeft <= 0f)
        {
            MorphingScript.modelA.SetActive(true);
            MorphingScript.modelB.SetActive(false);
            humanORAlienScript.SetToHumanState();
            //moveScript.WALKSpeed = 4;
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
            meterIsDone = false;
            InvokeRepeating("Countdown", 1, 1);
        }
        

        

    }

}


