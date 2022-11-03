using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip  picked, winSound,BG_sound;

 
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }
    private void Awake()
    {
        BG();
    }

  

public void PlayCollect()
    {  
        audioSource.PlayOneShot(picked);
    }
  


public void PlayWinSound()
{
    audioSource.PlayOneShot(winSound,1.2f);


}
    public void BG()
    {
        audioSource.PlayOneShot(BG_sound,0.4f);

    }
    public void SBG()
    {
        audioSource.Stop();

    }

  
}
