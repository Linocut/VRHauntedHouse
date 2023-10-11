using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OnCollision : MonoBehaviour
{
    public bool canChangeScenes = false;
    public string sceneName;

    SceneChanger changer;

    private void Start()
    {
        changer = SceneChanger.Instance;
    }

    public void EnableChange()
    {
        canChangeScenes = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canChangeScenes)
        {
            Debug.Log(other.gameObject.name);
            if (other.GetComponent<XROrigin>())
            {
                Debug.Log("player");
                changer.LoadScene(sceneName);
            }
            else if (other.GetComponent<CandleSpawn>())
            {
                other.GetComponent<CandleSpawn>().summon = false;
            }
        }
    }

}
