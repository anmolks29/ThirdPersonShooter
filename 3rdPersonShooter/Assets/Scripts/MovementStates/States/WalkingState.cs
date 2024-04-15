using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : MovementBaseState
{
    public override void EnterState(MovementStateManager movement)
    {
        movement.anim.SetBool("Walking", true);
    }

    public override void UpdateState(MovementStateManager movement)
    {
        if (Input.GetKey(KeyCode.RightShift))
        {
            ExitState(movement, movement.Run);
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            ExitState(movement, movement.Crouch);
        }
        else if (movement.dir.magnitude < 0.1f)
        {
            ExitState(movement, movement.Idle);
        }

        if (movement.vInput < 0)
        {
            movement.CurrentMoveSpeed = movement.walkSpeedBack;
        }
        else
        {
            movement.CurrentMoveSpeed = movement.walkSpeed;
        }
    }
    void ExitState(MovementStateManager movement, MovementBaseState state)
    {
        movement.anim.SetBool("Walking", false);
        movement.SwitchState(state);
    }
}
