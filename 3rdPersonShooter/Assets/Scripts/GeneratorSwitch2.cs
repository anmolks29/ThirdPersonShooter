using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorSwitch2 : MonoBehaviour
{
    public Light greenLight;
    public Light redLight;
    private bool playerHasSwitch;

    // Update is called once per frame
    void Update()
    {
        if (playerHasSwitch && Input.GetKeyDown(KeyCode.O))
        {
            TurnGeneratorOff();
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

    private void TurnGeneratorOff()
    {
        greenLight.enabled = false;
        redLight.intensity = 20;
        playerHasSwitch = false;
        Debug.Log("Generator is off");
    }
}
