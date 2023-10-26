using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CloseEyes : MonoBehaviour
{
    // Reference to the object to close eyes
    private GameObject eyesClose;
    public InputActionProperty eyeInputSource;
    private bool isClosed = false;
    public bool canClose = false;


    private void OnEnable()
    {
        eyeInputSource.action.Enable();

        eyeInputSource.action.started += OnButtonPressed;
    }

    private void OnDisable()
    {
        eyeInputSource.action.started -= OnButtonPressed;

        eyeInputSource.action.Disable();
    }

    private void OnButtonPressed(InputAction.CallbackContext context)
    {
        if (canClose)
        {
            if (!isClosed)
            {
                Close();
            }
            else
            {
                Open();
            }
        }
        
    }

        void Start()
    {
        GameObject cameraObj = GameObject.FindGameObjectWithTag("MainCamera");

        eyesClose = cameraObj.transform.Find("CloseEyesCanvas").gameObject;

        eyesClose.SetActive(false);
    }

    public void Close()
    {
        eyesClose.SetActive(true);
        isClosed = true; 
      
    }

    public void Open()
    {
        eyesClose.SetActive(false);
        isClosed = false; 
    }
}
