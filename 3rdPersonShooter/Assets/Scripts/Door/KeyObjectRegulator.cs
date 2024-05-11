using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeyNetwork
{
    public class KeyObjectRegulator : MonoBehaviour
    {
        [SerializeField] private bool keyIsFound = false;
        [SerializeField] private bool gateIsFound = false;
        [SerializeField] private KeyList keylist = null;

        private KeyOpenGate gateObject;

        private void Start()
        {
            if (gateIsFound)
            {
                gateObject = GetComponent<KeyOpenGate>();
            }
        }

        private void ObjectFound()
        {
            if (keyIsFound)
            {
                keylist.haskey = true;
                //gateObject.SetActive(false);
            }

            else if (gateIsFound)
            {
                return;
            }
        }
    }
}
