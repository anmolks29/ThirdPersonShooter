using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace KeyNetwork
{
    public class KeyRaycast : MonoBehaviour
    {
        [SerializeField] private int rayRadius = 10;
        [SerializeField] private LayerMask layerMaskCollective;
        [SerializeField] private string banLayerName = null;

        private KeyObjectRegulator raycastedObject;

        [SerializeField] private KeyCode openGateButton = KeyCode.O;
        [SerializeField] private Image crossHair = null;

        private bool checkCrossHair;
        private bool oneTime;
        private string collectiveTag = "CollectiveObject";


        private void Update()
        {
            RaycastHit hitInfo;
            Vector3 forwardDirection = transform.TransformDirection(Vector3.forward);
            int mask = 1 << LayerMask.NameToLayer(banLayerName) | layerMaskCollective.value;

            if(Physics.Raycast(transform.position, forwardDirection, out hitInfo, rayRadius, mask))
            {
                if(hitInfo.collider.CompareTag(collectiveTag))
                {
                    if(!oneTime)
                    {
                        raycastedObject = hitInfo.collider.gameObject.GetComponent<KeyObjectRegulator>();
                        
                    }
                }
            }
        }
    }
}
