using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class carBuilder : MonoBehaviour
{

    private bool osuma = false;

    public GameObject mainCar;
    public Rigidbody mainCarbody;
    public GameObject car1;
    public GameObject car2;
    public GameObject car3;
    public GameObject car4;
    public GameObject car5;

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "randcar")
        {
            if (!osuma){
                Debug.Log("AUTOOSUMA");
                HighScores.health -= 1;
                osuma = true;
            }
            osuma = false;
        }
    }
    

    void Start()
    {
        buildCars(2);
    }

    // Update is called once per frame
    void Update()
    {
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
    void buildCars(int count){
        for (var i=0; i < count; i++){
            buildCar1();
            buildCar2();
            buildCar3();
            buildCar4();
            buildCar5();
        }
    }
}
        

