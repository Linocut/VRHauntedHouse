using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    public float despawnTime; 
    void Start()
    {
        Invoke("Destroy", despawnTime);
    }

    void Destroy()
    {
        Destroy(this.gameObject);
    }
}
