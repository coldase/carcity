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
        Cursor.visible = false;
        AudioListener.pause = false;
        Debug.Log("RESUME pressed!");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }   
    void Pause()
    {
        Cursor.visible = true;
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
        Cursor.visible = true;
        AudioListener.pause = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        Debug.Log("Mainmenu toggled...");
    }
    public void RestartLevel()
    {
        Cursor.visible = false;
        Timer.resetTimer();
        AudioListener.pause = false;
        Timer.timerRunning = false;
        GameIsPaused = false;
        Time.timeScale = 1f;
        HighScores.laps = 1;
        TriggerTime.currentScore = 0;
        SceneManager.LoadScene(1);
    }

    public void SaveScores()
    {
        Debug.Log("Scores Saved");
    }
    
}

    
