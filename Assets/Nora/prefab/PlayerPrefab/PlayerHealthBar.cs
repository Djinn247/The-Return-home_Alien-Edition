using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerHealthBar : MonoBehaviour
{

    [SerializeField] private Image healthbar;
     private float healthAmount = 1;


      private void OnCollisionEnter(Collision other)
    {
        //if player touches the enemy and the healthbar is empty
        if (other.gameObject.CompareTag("Enemy") && healthAmount <= 0.0f)
        {

            Debug.Log("You died");
            SceneManager.LoadScene("SandBox");

        } 
        else if (other.gameObject.CompareTag("Enemy") && healthAmount > 0.0f)
        {
            healthAmount -= 15f * Time.deltaTime;
            healthbar.fillAmount = healthAmount;
        }

        


    }

}
