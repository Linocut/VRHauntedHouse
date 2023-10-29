using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionBed : MonoBehaviour
{
    
    public LightListener lightListener;
    public GameObject captionsCanvas; 
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        lightListener.CanTurnOff(); 
        captionsCanvas.GetComponent<SubtitleManager>().AddText("Don't Move.Press the Trigger to turn off lights.");
        Destroy(this.gameObject);
        
    }


}
