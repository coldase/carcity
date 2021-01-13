using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{    public void PlayGame()
    {

        statistiikka.score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("QUITTING!!");
        statistiikka.score = 0;
        Application.Quit();
    }

    public void TryAgain()
    {

        statistiikka.score = 0;
        Debug.Log("Trying again!");
        SceneManager.LoadScene("ajopeli_hiekkalaatikko");
    }

    public void MainMenu()
    {

        statistiikka.score = 0;
        SceneManager.LoadScene("Menu");
        Debug.Log("QUITTING!!");
    
    }

}    
