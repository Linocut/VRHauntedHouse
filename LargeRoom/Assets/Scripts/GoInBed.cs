using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GoInBed : MonoBehaviour
{
    public Transform newTransform;
    public GameObject playerObj;
    public GameObject managerObj; 
    public XRInteractionManager xrInteractionManager;
    // Start is called before the first frame update
    private void Awake()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
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

    public void GetInteract()
    {
        playerObj.GetComponent<Interact>().OnInteract(); 
    }
    public void GoIn(GameObject player)
    {
        
        Transform playerTransform = player.transform;

        if (newTransform != null)
        {
            playerTransform.position = newTransform.position;

            playerTransform.rotation = newTransform.rotation;

            playerTransform.localScale = newTransform.localScale;
        }
        else
        {
            Debug.LogError("The newTransform variable is not assigned. Please assign a Transform in the Inspector.");
        }
    }


}
