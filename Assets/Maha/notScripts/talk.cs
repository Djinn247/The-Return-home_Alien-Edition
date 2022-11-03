using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class talk : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject btn;
    [SerializeField] private Animator amy;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject TEXT;
    [SerializeField] private GameObject thiss;



    void Start()
    {
        btn.SetActive(false);
        panel.SetActive(false);
    }
     
    void Update()
    {
        
    }

    public void btnn()
    {  
        StartCoroutine(helpme());
   
         

    }
    IEnumerator helpme()
    {
        panel.SetActive(true);
        amy.SetBool("cry", false);
        amy.SetBool("talking", true);
        yield return new WaitForSeconds(5f);
        TEXT.SetActive(true);
        thiss.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
      if(other.gameObject==player)
        {
            StartCoroutine(TALK());


           
        }



    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            panel.SetActive(false);
            btn.SetActive(false);
            StopCoroutine(helpme());
            StopCoroutine(TALK());
        }
    }
    IEnumerator TALK()
    {
 
        btn.SetActive(true);
        amy.SetBool("talking",true);
        yield return new WaitForSeconds(0f);
       
    }




}
