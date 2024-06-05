using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowVehcileIndicator : MonoBehaviour
{

    public Animator animatorArrow1;
    public Animator animatorArrow2;
    public GameObject arrow;
    public static ArrowVehcileIndicator instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        
    }
    private void Update()
    {
       if(TimeBomb.instance.bombDeployed == true)
       {
            arrow.SetActive(true);
            AnimateArrow();
       }
    }
    public void AnimateArrow()
   {
        
        animatorArrow1.SetBool("ArrowMove", true);
        animatorArrow2.SetBool("ArrowMove", true);
   }
}
