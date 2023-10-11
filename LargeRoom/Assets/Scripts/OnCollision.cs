using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    public GameObject gameManager;
    public string sceneName; 
    void OnTriggerEnter()
    {
        gameManager.GetComponent<ChangeScene>().LoadScene(sceneName);
    }
}
