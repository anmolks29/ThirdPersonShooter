using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorOpen : MonoBehaviour
{
    public Animator animator;
    private bool playerOnGate = false;
    public GameObject doorOpenPopup;
    public GameObject withoutKeyPopup;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.O) && playerOnGate && KeyFunction.Instance.keyHasCollected == true)
        {
            OpenGate();
            KeyFunction.Instance.keyHasCollected = false;
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
        playerOnGate = false;
    }
}
