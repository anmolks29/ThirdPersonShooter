using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionMenu : MonoBehaviour
{
    public GameObject missionInfoPage;
    public GameObject keyMissionPage;
    public GameObject doorMissionPage;
    public GameObject switchMissionPage;
    public GameObject explosiveMissionPage;
    public GameObject vehicleMissionPage;
    public GameObject nextButton;
    public GameObject previousButton;
    public GameObject missionScene;
    public bool missionmenuActivated = false;

    private int pageViwed = 0;

    public void NextButtonClicked()
    {
        pageViwed++;
        Debug.Log(pageViwed + "time button clicked");
    } 
    public void PreviousButtonClicked()
    {
        pageViwed--;
        Debug.Log(pageViwed + "time button clicked");
    }


    private void Update()
    {
       
    }

    public void NextButton() 
    {
        if (pageViwed == 0)
        {
            keyMissionPage.SetActive(false);
            missionInfoPage.SetActive(true);
            previousButton.SetActive(false);
            Debug.Log("keyMissionPage viewed");
        } 
        
        if (pageViwed == 1)
        {
            keyMissionPage.SetActive(true);
            missionInfoPage.SetActive(false);
            previousButton.SetActive(true);
            Debug.Log("keyMissionPage viewed");
        } 
        
        if (pageViwed == 2)
        {
            
            keyMissionPage.SetActive(false);
            doorMissionPage.SetActive(true);
            previousButton.SetActive(true);
            Debug.Log("doorMissionPage viewed");
        }
        if (pageViwed == 3)
        {
            
            doorMissionPage.SetActive(false);
            switchMissionPage.SetActive(true);
            previousButton.SetActive(true);
            Debug.Log("switchMissionPage viewed");
        }
        
        if (pageViwed == 4)
        {
            
            switchMissionPage.SetActive(false);
            explosiveMissionPage.SetActive(true);
            previousButton.SetActive(true);
            Debug.Log("explosiveMissionPage viewed");
        }
        if (pageViwed == 5)
        {
            
            explosiveMissionPage.SetActive(false);
            vehicleMissionPage.SetActive(true);
            Debug.Log("vehicleMissionPage viewed");
            previousButton.SetActive(true);
            nextButton.SetActive(false);
            

        }
    }

    public void PreviousButton()
    {
        if (pageViwed == 5)
        {
            explosiveMissionPage.SetActive(false);
            vehicleMissionPage.SetActive(true);
            Debug.Log("vehicleMissionPage viewed");
            previousButton.SetActive(true);
            nextButton.SetActive(false);
        }
        if (pageViwed == 4)
        {
            vehicleMissionPage.SetActive(false);
            explosiveMissionPage.SetActive(true);
            previousButton.SetActive(true);
            nextButton.SetActive(true);
        }
        if (pageViwed == 3)
        {
            explosiveMissionPage.SetActive(false);
            switchMissionPage.SetActive(true);
            previousButton.SetActive(true);
            nextButton.SetActive(true);
        }
        if (pageViwed == 2)
        {
            switchMissionPage.SetActive(false);
            doorMissionPage.SetActive(true);
            previousButton.SetActive(true);
            nextButton.SetActive(true);
        }
        if (pageViwed == 1)
        {
            doorMissionPage.SetActive(false);
            keyMissionPage.SetActive(true);
            previousButton.SetActive(true);
            nextButton.SetActive(true);
            
        }
        if (pageViwed == 0)
        {
            keyMissionPage.SetActive(false);
            missionInfoPage.SetActive(true);
            previousButton.SetActive(false);
            nextButton.SetActive(true);
            Debug.Log("keyMissionPage viewed");
        }
    }

    public void MainMenuClicked()
    {
      
        Debug.Log("Main menu clicked");
    }

    public void MissionMenuActivation()
    {
        missionmenuActivated = true;
        Debug.Log("Mission menu activated");
    }
}
