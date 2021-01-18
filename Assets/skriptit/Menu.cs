using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{   
    public void PlayGame()
    {
        SceneManager.LoadScene("kentta01");
    }

    public void QuitGame()
    {
        Debug.Log("QUITTING!!");
        Application.Quit();
    }

    public void TryAgain()
    {

        Debug.Log("Trying again!");
        AudioListener.pause = false;
        Timer.timerRunning = false;
        Time.timeScale = 1f;
        HighScores.health = 5f;
        SceneManager.LoadScene("kentta01");
    }

    public void MainMenu()
    {

        SceneManager.LoadScene("Menu");
    
    }

    public void ScoreBoard()
    {
        SceneManager.LoadScene("ScoreBoardScene");
    }
    public void ToggleOptions()
    {
        SceneManager.LoadScene("optionsscene");
    }

}    
