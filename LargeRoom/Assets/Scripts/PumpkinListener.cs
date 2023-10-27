using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinListener : MonoBehaviour
{
    //listener gets spawned in when go in bed 
    public GameObject pumpkin;
    private GameObject camera;
    private SleepMonster sleepMonster;
    private GameObject canvas; 

    void Start()
    {
        //get the sleepMonster Script 
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        Transform childTransform = camera.transform.Find("CloseEyesCanvas");
        canvas = childTransform.gameObject;
        sleepMonster = canvas.GetComponent<SleepMonster>();
    }
    public void SpawnPumpkin()
    {
        if(sleepMonster.isDone = true)
        {
            pumpkin.SetActive(true);
        }
    }



}
