using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyAttack : MonoBehaviour
{

    [SerializeField] private int lives =3;
    [SerializeField] private Text lifeCount;

   
    private void OnCollisionEnter(Collision other)
    {
        //if player touches the enemy
        if (other.gameObject.CompareTag("Enemy") && lives == 1)
        {

            lifeCount.text = ("" + lives);

            Debug.Log("You died");
            SceneManager.LoadScene("SandBox");

        }
        else if (other.gameObject.CompareTag("Enemy") && lives > 1)
        {
            //while player is touching an enemy
            lives--;

            lifeCount.text = ("" + lives);
        }
        
            
    }
   
    
    }

