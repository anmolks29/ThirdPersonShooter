using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchState : MovementBaseState
{
   
    public override void EnterState(MovementStateManager movement)
    {
        movement.anim.SetBool("Crouching", true);
    }

    public override void UpdateState(MovementStateManager movement)
    {
        if (Input.GetKey(KeyCode.RightShift))
        {
            ExitState(movement, movement.Run);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (movement.dir.magnitude < 0.1f)
            {
                ExitState(movement, movement.Idle);
            }
            else
            {
                ExitState(movement, movement.Walk);
            }
        }
        if (movement.vInput < 0)
        {
            movement.CurrentMoveSpeed = movement.crouchSpeedBack;
        }
        else
        {
            movement.CurrentMoveSpeed = movement.crouchSpeed;
        }

    }
    void ExitState(MovementStateManager movement, MovementBaseState state)
    {
        movement.anim.SetBool("Crouching", false);
        movement.SwitchState(state);
    }
}
