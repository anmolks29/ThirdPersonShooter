using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseScene;
    public GameObject endGameScene;
    public GameObject crossHair;
    public GameObject missions;
    public static bool gameIsPaused = false;

    public static PauseMenu instance;

    private void Start()
    {
        instance = this;
        Cursor.lockState = CursorLockMode.Locked;
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                ResumeGame();
                
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                PauseGame();
               
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    public void ResumeGame()
    {
        pauseScene.SetActive(false);
        missions.SetActive(false);
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        gameIsPaused = false;
        crossHair.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("FPS_Shooter");
    }

    public void LoadMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("GameQuit");
        Application.Quit();
    }

    public void PauseGame()
    {

        
        pauseScene.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        crossHair.SetActive(false);
    }


}
