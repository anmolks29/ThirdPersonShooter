using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyFunction : MonoBehaviour
{
    public ParticleSystem glow;
    public bool keyHasCollected;
    public static KeyFunction Instance;


    private void Start()
    {
        Instance = this;
    }

    private void Update()
    {
        
    }
    public void DetachFromParent()
    {
        transform.parent = null;
        glow.Play();
        Debug.Log("Key Detached");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            keyHasCollected = true;
            Destroy(gameObject);
            MissionProgressBar.instance.ActiveBar1();
            
            Debug.Log("Key has collected");
        }
    }

  /* public void RevealKey()
    {
        if (SmgGun.instance.keyHasRaycast== true)
        {
            DetachFromParent();
        }
    }*/
}
