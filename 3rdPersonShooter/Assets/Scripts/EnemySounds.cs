using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySounds : MonoBehaviour
{
    private AudioSource m_AudioSource;

    [SerializeField] private AudioClip[] walksound;

    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    private AudioClip GetRandomFootStep()
    {
        return walksound[Random.Range(0, walksound.Length)];
    }
    private void Walk()
    {
        AudioClip clip = GetRandomFootStep();
        
        m_AudioSource.PlayOneShot(clip, 0.05f);
        
        
    }

}

