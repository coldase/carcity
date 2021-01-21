using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class TriggerTime : MonoBehaviour
{
    private bool Added = false;

    public GameObject car1;
    public GameObject car2;
    public GameObject car3;
    public GameObject car4;
    public GameObject car5;

    void Start()
    {
        AudioListener.pause = false;
        buildCars(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
           
    void addtoscorelist(float score)
    {
        if (score > 0){

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
                    Added = true;
                }
                Timer.resetTimer();
                destoryCars();
                buildCars(2);
                Timer.timerRunning = false;
                Added = false;
            }
        }
        Timer.timerRunning = true;
    }

    void buildCar1()
    {
        int rand_x = Random.Range(-130, -55);
        int rand_z = Random.Range(115, 124);
        Instantiate(car1, new Vector3(rand_x, 10, rand_z), Quaternion.identity);
    }
    void buildCar2()
    {
        int rand_x = Random.Range(0, 11);
        int rand_z = Random.Range(240, 244);
        Instantiate(car2, new Vector3(rand_x, 10, rand_z), Quaternion.identity);
    }
    void buildCar3()
    {
        int rand_x = Random.Range(-90, -220);
        int rand_z = Random.Range(275, 282);
        Instantiate(car3, new Vector3(rand_x, 10, rand_z), Quaternion.identity);
    }
    void buildCar4()
    {
        int rand_x = Random.Range(-295, -305);
        int rand_z = Random.Range(200, -60);
        Instantiate(car4, new Vector3(rand_x, 10, rand_z), Quaternion.identity);
    }
    void buildCar5()
    {
        int rand_x = Random.Range(-274, -242);
        int rand_z = Random.Range(-150, -140);
        Instantiate(car5, new Vector3(rand_x, 0, rand_z), Quaternion.identity);
    }
    public void buildCars(int count){
        for (var i=0; i < count; i++){
            buildCar1();
            buildCar2();
            buildCar3();
            buildCar4();
            buildCar5();
        }
    }

    void destoryCars()
    {
        GameObject[] cars = GameObject.FindGameObjectsWithTag("randcar");
        foreach(GameObject car in cars)
        {
            Debug.Log("cars removed");
            Destroy(car);
        }
    }
}