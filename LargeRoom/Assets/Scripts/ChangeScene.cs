using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    //bool will make pumpkin change scene then not when done 
    public bool isChanged = false; 
    // Function to change the scene
    public void LoadScene(string sceneName)
    {
        if (!isChanged)
        {
            Debug.Log("Load new scene");
            // Use SceneManager to load the specified scene
            SceneManager.LoadScene(sceneName);
            isChanged = true; 
        }
        
    }




}
