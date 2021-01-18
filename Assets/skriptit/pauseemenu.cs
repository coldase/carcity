using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseemenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else{
                Pause();
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
    }
    public void Resume()
    {
        AudioListener.pause = false;
        Debug.Log("RESUME pressed!");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }   
    void Pause()
    {
        AudioListener.pause = true;
        Debug.Log("PAUSE pressed!");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void QuitGame2()
    {
        Debug.Log("QUITTING!!");
        Application.Quit();
    }
    public void MainMenu2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        Debug.Log("Mainmenu toggled...");
    }
    public void RestartLevel()
    {
        AudioListener.pause = false;
        Timer.timerRunning = false;
        GameIsPaused = false;
        Time.timeScale = 1f;
        HighScores.health = 5f;
        SceneManager.LoadScene("kentta01");
    }

    public void SaveScores()
    {
        Debug.Log("Scores Saved");
    }
    
}

    
