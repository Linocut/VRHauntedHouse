using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score;

    void OnTriggerEnter(Collider other)
    {
        //if the other collider- gameobject
        //has a tag that says 'ball', increase the score by 1
        if (other.gameObject.tag == "ball")
        {
            score = score + 1;
        }
    }
}
