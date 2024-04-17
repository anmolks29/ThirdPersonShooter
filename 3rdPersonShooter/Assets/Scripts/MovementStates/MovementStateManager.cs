using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MovementStateManager : MonoBehaviour
{
    public float CurrentMoveSpeed;
    public float walkSpeed = 3, walkSpeedBack = 2.3f;
    public float runSpeed = 4, runSpeedBack = 3;
    public float crouchSpeed = 1.3f, crouchSpeedBack = 1;
    [HideInInspector] public Vector3 dir;
    public float hzInput;
    public float vInput;
    CharacterController controller;

    [SerializeField] float groundYoffset;
    [SerializeField] LayerMask groundMask;
    Vector3 spherePos;

    [SerializeField] float gravity = -9.81f;
    Vector3 velocity;

    private float playerHealth = 120f;
    private float currentPlayerHealth;

    MovementBaseState currentState;
    public IdleState Idle = new IdleState();
    public CrouchState Crouch = new CrouchState();
    public WalkingState Walk = new WalkingState();
    public RunningState Run = new RunningState();

    [HideInInspector] public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        SwitchState(Idle);
        currentPlayerHealth = playerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        GetDirectionAndMove();
        Gravity();
        currentState.UpdateState(this);
        anim.SetFloat("hzInput", hzInput);
        anim.SetFloat("vInput", vInput);
    }

    public void SwitchState(MovementBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    void GetDirectionAndMove()
    {
        hzInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        dir = transform.forward * vInput + transform.right * hzInput;

        controller.Move(dir.normalized * CurrentMoveSpeed * Time.deltaTime);
    }

    bool IsGrounded()
    {
        spherePos = new Vector3 (transform.position.x, transform.position.y -groundYoffset, transform.position.z);
        if(Physics.CheckSphere(spherePos,controller.radius - 0.05f, groundMask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void Gravity() 
    {
        if (!IsGrounded())
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else if(velocity.y < 0)
        {
            velocity.y = -2;
        }
        controller.Move(velocity * Time.deltaTime);
    }

  public void PlayerHitDamage(float takeDamage)
    {
        currentPlayerHealth -= takeDamage;
        if (currentPlayerHealth <= 0)
        {
            PlayerDie();
        }
    }

    private void PlayerDie()
    {
        Object.Destroy(gameObject, 2.0f);
    }
}
