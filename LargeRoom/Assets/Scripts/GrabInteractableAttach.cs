using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabInteractableAttach : MonoBehaviour
{
    private GameObject managerObj;
    private XRInteractionManager xrInteractionManager;
    // Start is called before the first frame update
    void Start()
    {
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

  
}
