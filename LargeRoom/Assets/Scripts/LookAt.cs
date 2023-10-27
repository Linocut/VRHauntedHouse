using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public GameObject player; 
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            // Make this object look at the player
            transform.LookAt(player.transform);
        }
        else
        {
            player = GameObject.FindWithTag("MainCamera");
        }
    }
}
