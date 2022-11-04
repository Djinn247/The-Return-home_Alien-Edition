using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SusBar : MonoBehaviour
{
    [SerializeField] private Image susMeter;
    [SerializeField]public float suspercentage;
    

    private void Start()
    {
      //  InvokeRepeating("CountDownn",1,1);
    }

    private void Update()
    {
        //0.016 since it's 60 seconds
        susMeter.fillAmount = suspercentage;

        if (susMeter.fillAmount == 1)
        {
            Debug.Log("DIE BITCH");
        }
    }




}
