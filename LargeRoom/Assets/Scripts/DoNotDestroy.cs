using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    // Ensure that this GameObject persists across scene changes
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
