using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseStop : MonoBehaviour
{
    private AudioSource audioSource; 
    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>(); 
    }
    // Start is called before the first frame update
    public void Stop()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
    public void ChangeClip(AudioClip newClip)
    {
        audioSource.clip = newClip;
        audioSource.Play();
    }
}
