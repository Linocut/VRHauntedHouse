using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject spawnObject;


    private Vector3 vectorPoint;
    //On Trigger Enter happens WHEN a
    //trigger collider has something enter it
    void OnTriggerEnter(Collider other)
    {
        //if the other collider- gameobject
        //has a tag that says 'lever all undercase, then spawn  ball
        if (other.gameObject.tag == "lever")
        {
            vectorPoint = spawnPoint.transform.position;
            Instantiate(spawnObject, vectorPoint, Quaternion.identity);
        }
            
    }
}
