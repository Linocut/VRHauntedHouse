using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    #region Singleton
    private static SceneChanger _instance;
    public static SceneChanger Instance
    {
        get => _instance;
        private set
        {
            if (_instance == null)
            {
                _instance = value;
                //DontDestroyOnLoad(value);
            }
            else if (_instance != value)
            {
                Debug.Log($"{nameof(SceneChanger)} instance already exists, destoying duplicate");
                Destroy(value);
            }
        }
    }

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    // Function to change the scene
    public void LoadScene(string sceneName)
    {
        Debug.Log("Load new scene");
        // Use SceneManager to load the specified scene
        SceneManager.LoadScene(sceneName);
    }
}
