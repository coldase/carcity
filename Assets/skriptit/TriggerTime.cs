using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using System;

public class TriggerTime : MonoBehaviour
{

    private int carsToBuild = 1;
    private bool Added = false;

    public GameObject car1;
    public GameObject car2;
    public GameObject car3;
    public GameObject car4;
    public GameObject car5;

    public static int currentScore = 0;
    private int lapScore;

    void Start()
    {
        buildCars(carsToBuild);
        AudioListener.pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        HighScores.topScore = currentScore;
    }
      
    private void OnTriggerEnter(Collider other)
    {
        if(Timer.timerRunning && secondTrigger.triggeredSecond){
            HighScores.laps += 1;
            lapScore += 500;
            //Timer.resetTimer();
            currentScore += lapScore - Timer.convTotalSeconds * 2;
            destoryCars();
            buildCars(carsToBuild);
            carsToBuild += 1;
        }


        Timer.timerRunning = true;

        secondTrigger.triggeredSecond = false;
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