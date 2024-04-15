using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public GameObject aimCam;
    public GameObject aimCanvas;
    public GameObject thirdPersonCam;
    public GameObject thirdPersonCanvas;

    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        AimZoom();
       // WalkNshoot();
       // SprintAnimation();
    }

    void AimZoom()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            animator.SetBool("Idle", false);
            animator.SetBool("IdleAim", true);

            thirdPersonCam.SetActive(false);
            thirdPersonCanvas.SetActive(false);
            aimCam.SetActive(true);
            aimCanvas.SetActive(true);


        }
        /*else if (Input.GetKey(KeyCode.Mouse1) && Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            Debug.Log("Walking and aiming");
            thirdPersonCam.SetActive(false);
            thirdPersonCanvas.SetActive(false);
            aimCam.SetActive(true);
            aimCanvas.SetActive(true);
        }*/


        else
        {
            thirdPersonCam.SetActive(true);
            thirdPersonCanvas.SetActive(true);
            aimCam.SetActive(false);
            aimCanvas.SetActive(false);
        }
    }

    void WalkNshoot()
    {
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.Mouse0))
        {
            animator.SetBool("FireWalk", true);
            Debug.Log("Walking and Shooting");
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetBool("Walk", true);
            animator.SetBool("Running", false);
            animator.SetBool("Idle", false);
            animator.SetBool("AimWalk", false);
            animator.SetBool("FireWalk", false);
            animator.SetBool("IdleAim", false);
        }
        else 
        {
            animator.SetBool("Walk", false);
            animator.SetBool("Running", false);
            animator.SetBool("Idle", true);
            animator.SetBool("AimWalk", false);
            animator.SetBool("FireWalk", false);
            animator.SetBool("IdleAim", false);
        }
    }

    void SprintAnimation()
    {
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightShift))
        {
            animator.SetBool("Running", true);
            animator.SetBool("Walk", false);
            animator.SetBool("Idle", false);
            animator.SetBool("IdleAim", false);
        }
        
        else
        {
            animator.SetBool("Walk", false);
            animator.SetBool("Idle", false);
        }
    }
}
