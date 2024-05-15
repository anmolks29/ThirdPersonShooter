using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;

   public void SetHealthToMax(float health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;
        
    }
    
    public void SetHealthToCurrent(float health)
    {
        healthSlider.value = health;
        
    }
}
