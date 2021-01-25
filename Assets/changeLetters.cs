using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class changeLetters : MonoBehaviour
{

    private char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

    public Text firstLetter;
    public Text secondLetter;
    public Text thirdLetter;
    public Text finalWord;

    private int firstChar;
    private int secondChar;
    private int thirdChar;

    private int currentChar;
    
    // Start is called before the first frame update
    void Start()
    {
        firstChar = 0;
        secondChar = 0;
        thirdChar = 0;
        currentChar = 0;
    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.LeftArrow) && currentChar > 0){
                currentChar -= 1;
            }
        if(Input.GetKeyDown(KeyCode.RightArrow) && currentChar < 2){
                currentChar += 1;
            }
        if(currentChar == 0){
            firstLetter.color = Color.red;
            secondLetter.color = Color.white;
            thirdLetter.color = Color.white;
            if(Input.GetKeyDown(KeyCode.UpArrow) && firstChar < 26){
                firstChar += 1;
            }    
            if(Input.GetKeyDown(KeyCode.DownArrow) && firstChar > 0){
                firstChar -= 1;
            }   
        }
        if(currentChar == 1){
            firstLetter.color = Color.white;
            secondLetter.color = Color.red;
            thirdLetter.color = Color.white;
            if(Input.GetKeyDown(KeyCode.UpArrow) && secondChar < 26){
                secondChar += 1;
            }    
            if(Input.GetKeyDown(KeyCode.DownArrow) && secondChar > 0){
                secondChar -= 1;
            }   
        }
        if(currentChar == 2){
            firstLetter.color = Color.white;
            secondLetter.color = Color.white;
            thirdLetter.color = Color.red;
            
            if(Input.GetKeyDown(KeyCode.UpArrow) && thirdChar < 26){
                thirdChar += 1;
            }    
            if(Input.GetKeyDown(KeyCode.DownArrow) && thirdChar > 0){
                thirdChar -= 1;
            }   
        }

        if(Input.GetKeyDown(KeyCode.Return)){
            finalWord.color = Color.green;
            finalWord.text = alpha.GetValue(firstChar).ToString() + alpha.GetValue(secondChar) + alpha.GetValue(thirdChar).ToString();
        }

        firstLetter.text = alpha.GetValue(firstChar).ToString();
        secondLetter.text = alpha.GetValue(secondChar).ToString(); 
        thirdLetter.text = alpha.GetValue(thirdChar).ToString();
    }
}