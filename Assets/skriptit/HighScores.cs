using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HighScores : MonoBehaviour
{   
    
    string converter(float seconds)
    {
        TimeSpan time = TimeSpan.FromSeconds(seconds);
        string str = time .ToString(@"mm\:ss");
        return str;
    }
    public static float topScore; 

    [SerializeField] Text scoreText1;
    

    void Start()
    {
        topScore = 999f;
    }

    void Update()
        {
            // topScores.Sort();
            scoreText1.text = "Best: " + converter(topScore).ToString();
        }
}
            