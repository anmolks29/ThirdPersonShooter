using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //[Header("Player Animator and Gravity")]
    public CharacterController characterController;
    public float playerSpeed = 1.9f;
    public float sprintSpeed = 3f;
    public float turnCalmTime = 0.1f;
    public float turnVelocity = 5.0f;
    

    public Transform playerCamera;
    Vector3 velocity;
    public float gravity = -9.81f;
    public float jumpRange = 1f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    bool onGround;
    public LayerMask groundMask;
    
    public Animator animator;

    private float playerMaxHealth = 120f;
    private float playerCurrentHealth;

    private void Start()
    {
        //Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        playerCurrentHealth = playerMaxHealth;
    }
    void Update()
    {
        
        onGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        if (onGround && velocity.y < 0)
        {
            velocity.y = -2f;
           
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);


        PlayerMove();
        Jump();
        Sprint();
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundCheck.position, groundDistance);
    }

    void PlayerMove () 
    {
        float vertical_axis = Input.GetAxisRaw("Vertical");
        float horizontal_axis = Input.GetAxisRaw("Horizontal");

        Vector3 direction = new Vector3 (horizontal_axis, 0 , vertical_axis).normalized;

        if (direction.magnitude >= 0.1f)
        {
            animator.SetBool("Walk", true);
            animator.SetBool("Running", false);
            animator.SetBool("Idle", false);
            animator.SetBool("AimWalk", false);
            animator.SetBool("IdleAim", false);
            animator.SetTrigger("Jump");

            
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + playerCamera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelocity, turnCalmTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f); // To Rotate left right, rotate in y axis.

            Vector3 moveDirection = Quaternion.Euler(0f,targetAngle, 0f) * Vector3.forward;
            characterController.Move (moveDirection.normalized * playerSpeed * Time.deltaTime);

        }
        
       
        else
        {
            animator.SetBool("Walk", false);
            animator.SetBool("Idle", true);
            animator.SetBool("AimWalk", false);
            animator.SetBool("IdleAim", false);
            animator.SetTrigger("Jump");
        }
    }  


    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            animator.SetTrigger("Jump");
            animator.SetBool("Walk", false);
            
            velocity.y = Mathf.Sqrt(jumpRange * -2 * gravity);
            
        }
        else
        {
            animator.ResetTrigger("Jump");
        }
    }

    void Sprint()
    {
        if (onGround && Input.GetKey(KeyCode.RightShift) && Input.GetKey(KeyCode.UpArrow))
        {
            float vertical_axis = Input.GetAxisRaw("Vertical");
            float horizontal_axis = Input.GetAxisRaw("Horizontal");

            Vector3 direction = new Vector3(horizontal_axis, 0, vertical_axis).normalized;

            if (direction.magnitude >= 0.1f)
            {
                animator.SetBool("Running", true);
                animator.SetBool("Walk", false);
                animator.SetBool("Idle", false);
                animator.SetBool("IdleAim", false);
                Debug.Log("Running");
                
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + playerCamera.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelocity, turnCalmTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f); // To Rotate left right, rotate in y axis.
                Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                characterController.Move(moveDirection.normalized * sprintSpeed * Time.deltaTime);

            }
            
            else
            {
                animator.SetBool("Walk", false);
                animator.SetBool("Idle", false);
            }
        }
  

    }

    public void PlayerHitDamage (float takeDamage)
    {
        playerCurrentHealth -= takeDamage; 
        if (playerCurrentHealth < 0)
        {
            PlayerDie();
        }
    }

    private void PlayerDie ()
    {
        Cursor.lockState = CursorLockMode.None;
        Object.Destroy(gameObject, 2.0f);
    }
    

   
    
}
