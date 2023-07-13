using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_Handler : MonoBehaviour
{
    
    public Collider deathArea;
    public Vector3 startPosition;

    private void OnTriggerEnter(Collider other)
    {
        
        if(other == deathArea)
        {
            transform.position =  startPosition;
        }
    }
}