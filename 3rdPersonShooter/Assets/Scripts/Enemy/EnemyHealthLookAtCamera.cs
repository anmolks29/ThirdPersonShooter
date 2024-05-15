using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthLookAtCamera : MonoBehaviour
{
    public Transform mainCamera;

    private void LateUpdate()
    {
        transform.LookAt(transform.position + mainCamera.forward);
    }
}
