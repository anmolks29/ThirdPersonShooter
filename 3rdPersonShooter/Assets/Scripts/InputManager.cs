using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerControl playerControl;

    public Vector2 movementInput;

    private void OnEnable()
    { 
        if (playerControl != null)
        {
            playerControl = new PlayerControl();
            playerControl.PlayerMovement.Movement.performed += i => i.ReadValue<Vector2>();
        }
        playerControl.Enable();
    }

    private void OnDisable()
    {
        playerControl.Disable();
    }
}

