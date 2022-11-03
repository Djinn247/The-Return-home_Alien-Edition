using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class flowers : MonoBehaviour
{

    
    [SerializeField] private Text flower;
     
    [SerializeField] private GameObject text;
    [SerializeField] private ParticleSystem cen;
    [SerializeField] public audio ao;
    [SerializeField] public Animator an;
    [SerializeField] private GameObject par;
    public int scor ;


    void Update()
    {
        
        flower.text = ("" + scor);
        if (scor == 3)
        {
            text.SetActive(true);
            dance();


        }
    }
    private void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("flower"))
        {
             
           ao.PlayCollect();
            scor += 1;
            Destroy(collisionInfo.gameObject);
        }
    }

   public void dance()
    {
        an.SetBool("yay", true);
       
        Instantiate(cen, par.transform.position, par.transform.rotation);
    }
  

    }
//end







