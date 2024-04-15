using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : MovementBaseState
{
    public override void EnterState(MovementStateManager movement)
    {

    }

    public override void UpdateState(MovementStateManager movement)
    {
        if (movement.dir.magnitude > 0.1f)
        {
            if (Input.GetKey(KeyCode.RightShift))
            {
                movement.SwitchState(movement.Run);
            }
            else
            {
                movement.SwitchState(movement.Walk);
            }
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            movement.SwitchState(movement.Crouch);
        }
    }
}
