using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restart : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private Transform start;

   
    private void OnTriggerEnter(Collider other)
    {
        Player.transform.position = start.transform.position;
        
    }
}
