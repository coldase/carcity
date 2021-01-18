using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TriggerTime : MonoBehaviour
{
    private bool Added = false;
    // Start is called before the first frame update
    void Start()
    {
        AudioListener.pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
           
    void addtoscorelist(float score)
    {
        if(score < scoreboard.score1)
        {
            scoreboard.score2 = scoreboard.score1;
            scoreboard.score1 = score;
        }
        else if(score > scoreboard.score1 && score < scoreboard.score2)
        {
            scoreboard.score3 = scoreboard.score2;
            scoreboard.score2 = score;
        }
        else if(score > scoreboard.score2 && score < scoreboard.score3)
        {
            scoreboard.score4 = scoreboard.score3;
            scoreboard.score3 = score;
        }
        else if(score > scoreboard.score3 && score < scoreboard.score4)
        {
            scoreboard.score4 = score;
        }
    }
            
    private void OnTriggerEnter(Collider other)
    {
        if (Timer.timerRunning)
        {
            if (Timer.currentSec > 5 || Timer.currentMin > 0){
                if (!Added){
                    if (HighScores.topScore > Timer.totalSeconds){
                        HighScores.topScore = Timer.totalSeconds;
                        addtoscorelist(Timer.totalSeconds);                   
                    }
                    Debug.Log(Timer.totalSeconds);
                    Added = true;
                }
                Timer.resetTimer();
                Timer.timerRunning = false;
                Added = false;
            }
        }
        Debug.Log("Triggered");
        Timer.timerRunning = true;
    }

}
