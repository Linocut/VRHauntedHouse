using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    public InputActionProperty interactInputSource;
    public float fovRadius;
    public float fovAngle;
    public LayerMask interactionMask;
    public LayerMask obstructionMask;
    private GameObject targetObject;
    private string passString;

    private string checkObject()
    {
        //the following code is the interaction logic 
        Collider[] rangeChecks = Physics.OverlapSphere(this.gameObject.transform.position, fovRadius, interactionMask);
        passString = "nothing";
        if (rangeChecks.Length != 0)
        {

            for (int i = 0; i < rangeChecks.Length; i++)
            {
                Transform target = rangeChecks[i].transform;
                Vector3 directionToTarget = (target.position - this.gameObject.transform.position).normalized;

                if (Vector3.Angle(transform.forward, directionToTarget) < fovAngle / 2)
                {
                    float distanceToTarget = Vector3.Distance(this.gameObject.transform.position, target.position);
                    if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                    {
                        targetObject = target.gameObject;
                        passString = target.gameObject.tag;
                        if (target.gameObject.tag != "Untagged")
                        {
                            return passString;
                        }

                    }
                }
            }
        }

        return passString;
    }
    public void OnInteract()
    {
        Debug.Log("Interact");
       
        string objectName = checkObject();
        if (objectName == "Bed")
        {
            targetObject.GetComponent<GoInBed>().GoIn(this.gameObject);
            Debug.Log("did it");
        }

        
    }
}