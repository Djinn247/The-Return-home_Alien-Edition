using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOOM : MonoBehaviour
{

    [SerializeField] GameObject ParticalSystem;

    // Update is called once per frame
    void Update()
    {
     
            Instantiate(ParticalSystem,transform.position,transform.rotation);
        
    }


    IEnumerator TALK()
    {
        Instantiate(ParticalSystem, transform.position, transform.rotation);
        yield return new WaitForSeconds(2f);

        Destroy(ParticalSystem);

    }
}
