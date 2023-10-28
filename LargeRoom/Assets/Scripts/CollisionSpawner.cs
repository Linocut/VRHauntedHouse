using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSpawner : MonoBehaviour
{
    public List<GameObject> spawnedObjects;
    public List<GameObject> despawnObjects;

    public string instructions;
    // Start is called before the first frame update
    void OnTriggerEnter()
    {
        for(int i = 0; i < spawnedObjects.Count; i++)
        {
            spawnedObjects[i].SetActive(true);
        }
        for (int i = 0; i < despawnObjects.Count; i++)
        {
            despawnObjects[i].SetActive(false);
        }
        this.gameObject.SetActive(false);

        SubtitleManager.instance.AddText(instructions);
    }
}
