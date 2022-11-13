using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Morph : MonoBehaviour
{
    public GameObject modelA;
    public GameObject modelB;
    [SerializeField] private AlienState AlienScript;
    public int modelNumber;



    [SerializeField] transformationScript TransMeterScript;
    [SerializeField] private ParticleSystem morphingdust;
    [SerializeField] private TMP_Text potionCounter;
    [SerializeField] private int amountOfPotions = 0;

    

    public bool isModelA = true;

    //first drink player takes.
    void Start()
    {
        /*
        modelNumber = 1;
        modelA.SetActive(true);
        morphingdust = GetComponent<ParticleSystem>();
        potionCounter.text = "x" + amountOfPotions; */
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && amountOfPotions > 0)
        {
            if (isModelA)
            {

                StartCoroutine("Transformation");

            }else
            {
                amountOfPotions--;
                TransMeterScript.CountUp();
                potionCounter.text = "x" + amountOfPotions;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Drink"))
        {
            CollectDrink();
            //StartCoroutine("Transformation");
        }

    }

    private void CollectDrink()
    {
        amountOfPotions++;

        potionCounter.text = "x" + amountOfPotions;
    }

    private IEnumerator Transformation()
    {
        modelA.GetComponent<Animator>().SetTrigger("Drank");
        amountOfPotions--;

        potionCounter.text = "x" + amountOfPotions;
        yield return new WaitForSeconds(1);
        morphingdust.Play();
        //Instantiate(morphingdust, modelA.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);
        TransMeterScript.CountUp();
        AlienScript.SetToAlienState();
        
    }

}