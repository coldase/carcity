﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


//Remake scoreboard:
//check if score > 0 and score < topScore

public class HighScores : MonoBehaviour
{   
    
    string converter(float seconds)
    {
        TimeSpan time = TimeSpan.FromSeconds(seconds);
        string str = time .ToString(@"mm\:ss");
        return str;
    }
    public static float topScore; 
    public static float health;

    [SerializeField] Text scoreText1;
    [SerializeField] Text healthText;
    

    void Start()
    {
        topScore = 999f;
        health = 5f;
    }

    void Update()
    {
        scoreText1.text = "Best: " + converter(topScore).ToString();
        healthText.text = health.ToString() + " hp";
    
        if (health <= 0)
        {
            SceneManager.LoadScene("losescene");
        }
    
    }
}           