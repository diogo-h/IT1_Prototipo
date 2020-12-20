using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public bool gameIsPaused {get; private set;}
    public GameObject pauseMenuUI;
    private Obstacles playerState;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused)
                Resume();
            else
                Pause();
        }
        if(playerState != null)
            if(playerState.isAlive == false)
                DeathScreen();
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        gameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        gameIsPaused = true;
    }

    public void DeathScreen()
    {
        Time.timeScale = 0.0f;
        SceneManager.LoadScene("MainMenu");
        
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1.0f;
    }

    public void PlayTutorial()
    {
        SceneManager.LoadScene("tutorial_01");
        Time.timeScale = 1.0f;
    }
}