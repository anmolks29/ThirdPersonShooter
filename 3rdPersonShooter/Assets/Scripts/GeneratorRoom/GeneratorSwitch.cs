using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorSwitch : MonoBehaviour
{
    public Light greenLight;
    public Light redLight;
    private bool playerHasSwitch;
    public bool generatorTurnedOff1 = false; 
    public GameObject switchPopup;

    public static GeneratorSwitch instance;


    private void Start()
    {
        instance = this;
        GeneratorSound1.instance.PlayGeneratorSound();
    }
    void Update()
    {
        if (playerHasSwitch && Input.GetKeyDown(KeyCode.I))
        {
            TurnGeneratorOff();
            generatorTurnedOff1 = true;
            MissionProgressBar.instance.ActiveBar3();
        }

        if(playerHasSwitch==true && generatorTurnedOff1 == false)
        {
            switchPopup.SetActive(true);
        }
        else
        {
            switchPopup.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerHasSwitch = true;
            
            Debug.Log("Generator is off");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerHasSwitch = false;
            
            Debug.Log("Generator is off");
        }
    }

    private void TurnGeneratorOff()
    {
        greenLight.enabled = false;
        redLight.intensity = 20;
        playerHasSwitch = false;
        GeneratorSound1.instance.StopGeneratorSound();
        Debug.Log("Generator is off");
    }
}
