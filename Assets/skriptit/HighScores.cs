using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class HighScores : MonoBehaviour
{   
    
    
    public static int topScore; 
    public static int laps;

    [SerializeField] Text scoreText1 = null;
    [SerializeField] Text healthText = null;
    

    void Start()
    {
        topScore = 0;
        laps = 1;
    }

    void Update()
    {
        scoreText1.text = "Score: " + topScore.ToString();
        healthText.text = "Lap " + laps.ToString() + "/3";
    
        if (laps >= 4)
        {
            
            SceneManager.LoadScene("scoreUI");
            Cursor.visible = true;
            topScore = TriggerTime.currentScore;
            topScoreScript.youScored = topScore;
        }
    }
}