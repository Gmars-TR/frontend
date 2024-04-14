using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgMusicControl : MonoBehaviour
{
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // Play the background music
        audioSource.Play();
    }
 
}
