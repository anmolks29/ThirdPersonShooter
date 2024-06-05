using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSwitchIndicator : MonoBehaviour
{

    public Animator animatorArrow1;
    public Animator animatorArrow2;
    public GameObject arrow1;
    public GameObject arrow2;
    public static ArrowSwitchIndicator instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        
    }
    private void Update()
    {
        animatorArrow1.SetBool("ArrowMove", true);
        animatorArrow2.SetBool("ArrowMove", true);

        if (DoorOpen.instance.doorOpened == true)
       {
            arrow1.SetActive(true);
            arrow2.SetActive(true);
            AnimateArrow1();
            AnimateArrow2();
       }

       if(GeneratorSwitch.instance.generatorTurnedOff1 == true)
       {
            animatorArrow1.SetBool("ArrowMove", false);
            arrow1.SetActive(false);
       }
       
        if(GeneratorSwitch2.instance.generatorTurnedOff2 == true)
        {
            animatorArrow2.SetBool("ArrowMove", false);
            arrow2.SetActive(false);
        }
    }
    public void AnimateArrow1()
    {
        
        animatorArrow1.SetBool("ArrowMove", true);
        
    }
    public void AnimateArrow2()
    {
        
        
        animatorArrow2.SetBool("ArrowMove", true);
    }
}
