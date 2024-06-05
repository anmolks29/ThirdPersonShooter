using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorSound1 : MonoBehaviour
{
    
    
    public AudioSource audioSource;

    public static GeneratorSound1 instance;

    public void Start()
    {
        instance = this;
    }

    public void PlayGeneratorSound()
    {
        audioSource.Play();
        Debug.Log("1st generator sound is playing");
    }

    public void StopGeneratorSound()
    {
        audioSource.Stop();
    }
}
