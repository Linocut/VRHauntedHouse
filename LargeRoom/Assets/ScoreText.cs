using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public Score scoreScript;
    public Text textComponent; 
    // Update is called once per frame
    void Update()
    {
        textComponent.text = scoreScript.score.ToString(); 
    }
}
