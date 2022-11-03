using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collection : MonoBehaviour
{
    
    [SerializeField] public int points;

    [SerializeField] private Text Drinkcount;

  
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {

            Destroy(other.gameObject);
            points++;
            Drinkcount.text = (""+ points);

            if (points == 10)
            {
                Debug.Log("YOU WIN!!!");
            }

        }
    }

}