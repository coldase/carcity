using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class carBuilder : MonoBehaviour
{

    private bool osuma = false;

    public GameObject mainCar;
    public Rigidbody mainCarbody;
    

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "randcar")
        {
            if (!osuma){
                Debug.Log("AUTOOSUMA");
                TriggerTime.currentScore -= 100;
                osuma = true;
            }
            osuma = false;
        }
    }
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    
    
}

        

