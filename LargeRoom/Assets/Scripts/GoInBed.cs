using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GoInBed : MonoBehaviour
{
    public Transform newTransform;
    public GameObject playerObj;
    public GameObject XROriginObj;
    public GameObject managerObj; 
    public XRInteractionManager xrInteractionManager;
    // Start is called before the first frame update
    private void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        XROriginObj = GameObject.FindGameObjectWithTag("XROrigin");
        managerObj = GameObject.FindGameObjectWithTag("GameController");
        xrInteractionManager = managerObj.GetComponent<XRInteractionManager>();
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();

        if (grabInteractable != null && xrInteractionManager != null)
        {
            // Set the XR Interaction Manager for the XR Grab Interactable
            grabInteractable.interactionManager = xrInteractionManager;
        }
        else
        {
            Debug.LogError("XR Grab Interactable or XR Interaction Manager not assigned.");
        }
    }
  

    public void GoIn()
    {
        Transform playerTransform = XROriginObj.transform;
        Debug.Log("Player original" + playerTransform);
        Debug.Log("New transform " + newTransform);
        playerObj.GetComponent<CloseEyes>().canClose = true; 
        if (newTransform != null)
        {
            playerTransform.position = newTransform.position;

            //playerTransform.rotation = newTransform.rotation;
        }
        else
        {
            Debug.LogError("The newTransform variable is not assigned. Please assign a Transform in the Inspector.");
        }

        Debug.Log("player New" + playerTransform);
    }


}
