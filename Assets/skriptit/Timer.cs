using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Rigidbody mainCarBody;
    // public static float currentTime;
    public static float currentMin = 0f;
    public static float totalSeconds;
    
    public static float currentSec = 0f;
    float startingTime = 0f;

    public static bool timerRunning = false;


    [SerializeField] Text timerText;
    [SerializeField] Text speedText;

    void Start()
    {
        currentSec = startingTime;   
    }

    void Update()
    {
        if (timerRunning)
        {
            currentSec += 1 * Time.deltaTime;
            totalSeconds += 1 * Time.deltaTime;
            if (currentSec >= 60){
                currentMin += 1;
                currentSec = 0f;
            }
            timerText.text = currentMin.ToString("0:") + currentSec.ToString("00");
        }
        speedText.text = System.Math.Round(mainCarBody.velocity.magnitude * 3.6, 0).ToString() + " km/h";
    }

        
    public static void resetTimer()
    {
        currentMin = 0f;
        currentSec = 0f;
        totalSeconds = 0f;
    }
}
   


