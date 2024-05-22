using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBomb : MonoBehaviour
{

    public bool ShowTimeBombPopup = false;
    public GameObject timeBombPopup;
    public GameObject timeBomb;
    public GameObject timeRemainingPopup;
    public GameObject findTheCar;
    public GameObject getInsideCarPopup;
    public bool bombDeployed = false;
    public float timeLeft = 30f;
    public bool timerOn = false;
    public Text startText;

    public ParticleSystem blast;
    public ParticleSystem fire;
    public ParticleSystem smoke;
    public AudioSource countDownSound;
    public AudioSource bombSound;
    
    public static TimeBomb instance;
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (GeneratorSwitch.instance.generatorTurnedOff1 == true && GeneratorSwitch2.instance.generatorTurnedOff2 ==true && ShowTimeBombPopup == true && bombDeployed == false)
        {
            timeBombPopup.SetActive(true);
        }
        else
        {
            timeBombPopup.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.P) && GeneratorSwitch.instance.generatorTurnedOff1 == true && GeneratorSwitch2.instance.generatorTurnedOff2 == true)
        {
            timeBomb.SetActive(true);
            ShowTimeBombPopup = false;
            timeRemainingPopup.SetActive(true);
            countDownSound.Play();
            bombDeployed = true;
            timerOn = true;
        }

        if(ArmoredCar.instance.reachedGetInsideCar == true)
        {
            getInsideCarPopup.SetActive(true);
        }
        else 
        { 
            getInsideCarPopup.SetActive(false);
        }

        

        

        if (timerOn)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                UpdateTimer(timeLeft);
                
            }
            else
            {
                timeLeft = 0;
                timerOn = false;
                
                timeRemainingPopup.SetActive(false);
                PlayExplosion();
                
            }
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ShowTimeBombPopup = true;
            Debug.Log("Show Time bomb popup");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ShowTimeBombPopup = false;
            
        }
    }

    public void UpdateTimer(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        startText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    public void PlayExplosion()
    {

        Debug.Log("Entered into explosion function");
        bombSound.Play();
        blast.Play();
        fire.Play();
        smoke.Play();
        countDownSound.Stop();
        Debug.Log("All the effects played in explosion function");
    }
}
