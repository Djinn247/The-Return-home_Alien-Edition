using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class transformationScript : MonoBehaviour
{
    [SerializeField] private Image TransformBar;
    //[SerializeField] Morph MorphingScript;
    public float timeLeft;


    private void Start()
    {
        InvokeRepeating("Countdown", 1, 1);
    }

    private void Update()
    {
        //meterBar.fillAmount = timeLeft;

        //if (timeLeft < 0)
        //{
        //MorphingScript.modelA.SetActive(true);
        //}


        //}
        Debug.Log(timeLeft);
    }
        private void Countdown()
        {
            timeLeft -= 0.016f;
        }

        public void CountUp()
        {
            timeLeft += 0.5f;

        }

    }


      