using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorSwitch2 : MonoBehaviour
{
    public Light greenLight;
    public Light redLight;
    private bool playerHasSwitch;
    public GameObject switchPopup;
    public bool generatorTurnedOff2;

    public static GeneratorSwitch2 instance;


    private void Start()
    {
        instance = this;
        GeneratorSound2.instance.PlayGeneratorSound();
    }
    void Update()
    {
        if (playerHasSwitch && Input.GetKeyDown(KeyCode.I))
        {
            TurnGeneratorOff();
            generatorTurnedOff2 = true;
        }
        if (playerHasSwitch == true && generatorTurnedOff2 == false)
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
            
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerHasSwitch = false;

            
        }
    }

    private void TurnGeneratorOff()
    {
        greenLight.enabled = false;
        redLight.intensity = 20;
        playerHasSwitch = false;
        GeneratorSound2.instance.StopGeneratorSound();
        Debug.Log("Generator is off");
    }
}
