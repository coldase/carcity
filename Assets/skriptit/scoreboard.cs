using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class scoreboard : MonoBehaviour
{

    
    string converter(float seconds)
    {
        TimeSpan time = TimeSpan.FromSeconds(seconds);
        string str = time .ToString(@"mm\:ss");
        return str;
    }
    
    public static float score1 = 2013f;
    public static float score2 = 2013f;
    public static float score3 = 2013f;
    public static float score4 = 2013f;

    float[] scoreList = {score1, score2, score3, score4};
    List<float> finalList = new List<float>();
    void sortting()
    {
        List<float> templist = new List<float>();
        for(var i=0; i< scoreList.Length;i++)
        {
            templist.Add(scoreList[i]);
        }
        templist.Sort();
        foreach(var item in templist){
            finalList.Add(item);
        } 
    }

    [SerializeField] Text scoreText1;
    [SerializeField] Text scoreText2;
    [SerializeField] Text scoreText3;
    [SerializeField] Text scoreText4;
    void Start()
    {

        sortting();

        scoreText1.text = "1st - " + converter(finalList[0]).ToString();
        scoreText2.text = "2nd - " + converter(finalList[1]).ToString();
        scoreText3.text = "3rd - " + converter(finalList[2]).ToString();
        scoreText4.text = "4th - " + converter(finalList[3]).ToString();

    }

    // Update is called once per frame
    void Update()
    {
    }
}
