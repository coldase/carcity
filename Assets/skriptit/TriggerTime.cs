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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Timer.timerRunning)
        {
            if (Timer.currentSec > 5 || Timer.currentMin > 0){
                if (!Added){
                    if (HighScores.topScore > Timer.totalSeconds){
                        HighScores.topScore = Timer.totalSeconds;
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
