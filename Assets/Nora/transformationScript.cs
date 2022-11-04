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
    [SerializeField] Morph MorphingScript;
    public float timeLeft;


    private void Start()
    {

    }

    private void Update()
    {
        //  TransformBar.fillAmount = timeLeft *0.01f;

       

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
            CancelInvoke("Countdown");
        }
    }

    public void CountUp()
    {

        if (timeLeft <= 1)
        {
            timeLeft += 1;
            TransformBar.fillAmount = timeLeft;
            humanORAlienScript.SetToAlienState();
        }

        InvokeRepeating("Countdown", 1, 1);

    }

}


