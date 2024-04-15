using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float healthDamage = 100f;


    public void HitDamage (float amount)
    {
        healthDamage -= amount;
        if (healthDamage <= 0f)
        {
            
            Destroy(gameObject);
            

        }
    }
}
