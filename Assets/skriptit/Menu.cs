﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{   
    public void PlayGame()
    {
        Cursor.visible = false;
        Debug.Log("Newgame");
        AudioListener.pause = false;
        Timer.timerRunning = false;
        Timer.resetTimer();
        Time.timeScale = 1f;
        HighScores.laps = 1;
        TriggerTime.currentScore = 0; 
        SceneManager.LoadScene("kentta01");
    }

    public void QuitGame()
    {
        Debug.Log("QUITTING!!");
        Application.Quit();
    }

    public void TryAgain()
    {
        Cursor.visible = false;
        Debug.Log("Trying again!");
        AudioListener.pause = false;
        Timer.timerRunning = false;
        Time.timeScale = 1f;
        Timer.resetTimer();
        HighScores.laps = 1;
        TriggerTime.currentScore = 0; 
        SceneManager.LoadScene("kentta01");
    }

    public void MainMenu()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("Menu");
    
    }

    public void ScoreBoard()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("scoreUI");
    }
    public void ToggleOptions()
    {
        SceneManager.LoadScene("optionsscene");
    }

}    
