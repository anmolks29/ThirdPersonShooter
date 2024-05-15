using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCount : MonoBehaviour
{
    public Slider ammoSlider;
    public Text magText;

    public static AmmoCount Instance;

    public void Awake()
    {
        Instance = this;
    }

    public void UpdateAmmoMax(int presentAmmo)
    {
        ammoSlider.maxValue =  presentAmmo;
        ammoSlider.value = presentAmmo;
    }
    public void UpdateAmmoCurrent(int presentAmmo)
    {
        ammoSlider.value =  presentAmmo;
    }

    public void UpdateMag (int mag)
    {
        magText.text = "mag remaining - " + mag;
    }
}
