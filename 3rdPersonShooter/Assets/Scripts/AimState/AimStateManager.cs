using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class AimStateManager : MonoBehaviour
{
    AimBaseState currentState;
    public HipFireState Hip = new HipFireState();
    public AimState Aim = new AimState();
    float mouseSense = 2;
    public float xAxis, yAxis;
    [SerializeField] Transform camFollowPos;
    [HideInInspector] public Animator anim;

    [HideInInspector] public CinemachineVirtualCamera VirtualCamera;
    public float adsFov = 40;
    [HideInInspector] public float hipFov;
    [HideInInspector] public float currentFov;
    public float fovSnoothSpeed = 10;


    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        VirtualCamera = GetComponentInChildren<CinemachineVirtualCamera>();
        hipFov = VirtualCamera.m_Lens.FieldOfView;
        SwitchState(Hip);
    }

   

    // Update is called once per frame
    void Update()
    {
        xAxis += Input.GetAxisRaw("Mouse X") * mouseSense;
        yAxis -= Input.GetAxisRaw("Mouse Y") * mouseSense;
        yAxis = Mathf.Clamp(yAxis, -80, 80);
        VirtualCamera.m_Lens.FieldOfView = Mathf.Lerp(VirtualCamera.m_Lens.FieldOfView, currentFov , fovSnoothSpeed *  Time.deltaTime);
        currentState.UpdateState(this);
    }

    private void LateUpdate()
    {
        camFollowPos.localEulerAngles = new Vector3(yAxis, camFollowPos.localEulerAngles.y, camFollowPos.localEulerAngles.z);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, xAxis, transform.eulerAngles.z);
    }

    public void SwitchState(AimBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}
