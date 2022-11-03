using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class fun_sc : MonoBehaviour
{
[SerializeField] private string scene;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

public void PlayGame()
    {
        SceneManager.LoadScene(scene);
    }
   public void QuitGame()
    {
        Application.Quit();
    }

}
