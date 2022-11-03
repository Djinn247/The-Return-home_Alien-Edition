using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink : MonoBehaviour
{
    [SerializeField] transformationScript TransMeterScript;
    public GameObject modelA;
    public GameObject modelB;
    private int modelNumber;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Human"))
        {
            modelA.SetActive(false);
            modelB.SetActive(true);
            modelNumber = 2;
            Destroy(gameObject);
            TransMeterScript.timeLeft += 0.5f;
        }

    }

}
