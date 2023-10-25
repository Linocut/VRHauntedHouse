using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnterExit : MonoBehaviour
{
    public bool inTrigger; 
    private void OnTriggerEnter(Collider other)
    {
        inTrigger = true;
    }
    private void OnTriggerExit(Collider other)
    {
        inTrigger = false; 
    }
}
