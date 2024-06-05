using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorOpen : MonoBehaviour
{
    public Animator animator;
    private bool playerOnGate = false;
    public bool doorOpened = false;
    public GameObject doorOpenPopup;
    public GameObject withoutKeyPopup;
    public AudioSource audioSource;
    public AudioClip doorOpeningSound;

    public static DoorOpen instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;   
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.O) && playerOnGate && KeyFunction.Instance.keyHasCollected == true)
        {
            OpenGate();
            MissionProgressBar.instance.ActiveBar2();
            KeyFunction.Instance.keyHasCollected = false;
            doorOpened = true;
        }
        if (playerOnGate && KeyFunction.Instance.keyHasCollected == false)
        {
            withoutKeyPopup.SetActive(true);
        }
        else
        {
            withoutKeyPopup.SetActive(false);
        }

        if (playerOnGate == true && KeyFunction.Instance.keyHasCollected == true)
        {
            doorOpenPopup.SetActive(true);
        }
        else
        {
            doorOpenPopup.SetActive(false);
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnGate = true;
           
            Debug.Log("Popup played");
        }
        
    } private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnGate = false;
           
            Debug.Log("Popup played");
        }
        
    }

    private void OpenGate()
    {
        Debug.Log("Open the gate");
        animator.SetBool("DoorOpen", true);
        audioSource.PlayOneShot(doorOpeningSound);
        playerOnGate = false;
    }
}
