using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MissionProgressBar : MonoBehaviour
{
    public Image key;
    public Image door;
    public Image generatorSwitch;
    public Image explosive;

    public GameObject blueBar1;
    public GameObject blueBar2;
    public GameObject blueBar3;
    public GameObject blueBar4;
    public GameObject blueBar5;

    public GameObject grayBar1;
    public GameObject grayBar2;
    public GameObject grayBar3;
    public GameObject grayBar4;
    public GameObject grayBar5;
     

    public static MissionProgressBar instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void ActiveBar1()
    {
        blueBar1.SetActive(true);
        grayBar1.SetActive(false);
    }

    public void ActiveBar2()
    {
        blueBar2.SetActive(true);
        grayBar2.SetActive(false);
    }
    public void ActiveBar3()
    {
        blueBar3.SetActive(true);
        grayBar3.SetActive(false);
    }
    public void ActiveBar4()
    {
        blueBar4.SetActive(true);
        grayBar4.SetActive(false);
    }
    public void ActiveBar5()
    {
        blueBar5.SetActive(true);
        grayBar5.SetActive(false);
    }
}
