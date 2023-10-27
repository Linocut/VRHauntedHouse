using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class LightListener : MonoBehaviour
{
    public InputActionProperty eyeInputSource;
    public List<GameObject> lights;
    public bool isOff;
    private bool canTurnOff = false;
    public PumpkinListener pumpkinListener; 


    public void CanTurnOff()
    {
        canTurnOff = true; 
    }
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
        if (canTurnOff)
        {
            if (!isOff)
            {
                Off();
            }
            else
            {
                On();
            }
        }
 
    }
    private void Off()
    {
        for(int i=0; i< lights.Count; i++)
        {
            lights[i].SetActive(false);

        }
        isOff = true; 


    }
    private void On()
    {
        for (int i = 0; i < lights.Count; i++)
        {
            lights[i].SetActive(true);
        }
        isOff = false;
        pumpkinListener.SpawnPumpkin();
    }



}
