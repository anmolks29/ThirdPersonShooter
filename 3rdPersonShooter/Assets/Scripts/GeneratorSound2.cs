using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorSound2 : MonoBehaviour
{
    
    
    public AudioSource audioSource;

    public static GeneratorSound2 instance;

    public void Start()
    {
        instance = this;
    }
    public void PlayGeneratorSound()
    {
        audioSource.Play();
        Debug.Log("2nd generator sound is playing");
    }

    public void StopGeneratorSound()
    {
        audioSource.Stop();
    }
}
