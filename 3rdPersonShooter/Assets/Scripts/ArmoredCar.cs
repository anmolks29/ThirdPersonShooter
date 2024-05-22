using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmoredCar : MonoBehaviour
{
    
    
    public bool getInsideCar = false;
    public bool reachedGetInsideCar = false;

    public static ArmoredCar instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(getInsideCar == true && TimeBomb.instance.bombDeployed == true)
        {

            reachedGetInsideCar = true;
        }
        else
        {
            reachedGetInsideCar = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            getInsideCar = true;
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            getInsideCar = false;
        }
    }
}
