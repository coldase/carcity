﻿
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class kirjoita : MonoBehaviour
{
    public Text merkki1;
    public Text merkki2;
    public Text merkki3;
    public Text ok;
    private int paikka;
    private int merkin1Aakkonen;
    private int merkin2Aakkonen;
    private int merkin3Aakkonen;
    

    // VÄLIAIKAINEN PISTEET
    public int pisteet;

    private string[] aakkoset = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

    private int onkoLista;


    private void Start()
    {
        //Tsekkaa onko lista olemassa
        onkoLista = PlayerPrefs.GetInt("listaOlemassa");

        //Jos ei, tekee sen, ns dummydata
        if (onkoLista == 0)
        {
            PlayerPrefs.SetString("top1_nimi", "KOL");
            PlayerPrefs.SetString("top2_nimi", "KAI");
            PlayerPrefs.SetString("top3_nimi", "MAX");
            PlayerPrefs.SetInt("top1_score", 888);
            PlayerPrefs.SetInt("top2_score", 555);
            PlayerPrefs.SetInt("top3_score", 333);
            PlayerPrefs.SetInt("listaOlemassa", 1);
        }

        //Laittaa tekstin näytölle
        merkki1.text = aakkoset[merkin1Aakkonen];
        merkki2.text = aakkoset[merkin2Aakkonen];
        merkki3.text = aakkoset[merkin3Aakkonen];
        ok.text = "ANNA NIMI";
        paikka = 1;

    }
    void Update()
    {
        //Tsekkaa inputit
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            seuraavaKirjainIsompi();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            seuraavaKirjainPienempi();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (paikka > 3)
            {
                paikka = 4;
            }
            else paikka++;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (paikka > 1)
            {
                paikka--;
            }
            else paikka = 1;
        }
        if (paikka == 4 && Input.GetKeyDown(KeyCode.Space))
        {
            tallenna();
           // SceneManager.LoadScene(0);
        }
        tarkistaVari();
        paivitaMerkit();
    }

    public void tallenna()
    {
        //ladataan vanhat tiedot
        string nimi = merkki1.text + merkki2.text + merkki3.text;
        int top1 = PlayerPrefs.GetInt("top1_score");
        int top2 = PlayerPrefs.GetInt("top2_score");
        int top3 = PlayerPrefs.GetInt("top1_score");
        string nimi1 = PlayerPrefs.GetString("top1_nimi");
        string nimi2 = PlayerPrefs.GetString("top2_nimi");
        string nimi3 = PlayerPrefs.GetString("top3_nimi");

        // vertaillaan
        if (pisteet > top1)
        {
            top3 = top2;
            nimi3 = nimi2;
            top2 = top1;
            nimi2 = nimi1;
            top1 = pisteet;
            nimi1 = nimi;
        }
        else if (pisteet > top2)
        {
            top3 = top2;
            nimi3 = nimi2;
            top2 = pisteet;
            nimi2 = nimi;
        }
        else if (pisteet > top3)
        {
            top3 = pisteet;
            nimi3 = nimi;
        }

        // tallennetaan
        PlayerPrefs.SetString("top1_nimi", nimi1);
        PlayerPrefs.SetString("top2_nimi", nimi2);
        PlayerPrefs.SetString("top3_nimi", nimi3);
        PlayerPrefs.SetInt("top1_score", top1);
        PlayerPrefs.SetInt("top2_score", top2);
        PlayerPrefs.SetInt("top3_score", top3);


    }

    //Muuttaa tekstikenttiin uudet merkit
    private void paivitaMerkit()
    {
        merkki1.text = aakkoset[merkin1Aakkonen];
        merkki2.text = aakkoset[merkin2Aakkonen];
        merkki3.text = aakkoset[merkin3Aakkonen];
        if (paikka > 3)
        {
            ok.text = "OK";
            ok.color = Color.white;
           
        }
        else
        {
            ok.text = "ANNA NIMI";
            ok.color = Color.yellow;
            

        }
    }

    private void seuraavaKirjainIsompi()
    {
        if (paikka == 1)
        {
            if (merkin1Aakkonen == aakkoset.Length - 1)
            {
                merkin1Aakkonen = 0;
            }
            else
            {
                merkin1Aakkonen++;
            }

        }
        else if (paikka == 2)
        {
            if (merkin2Aakkonen == aakkoset.Length - 1)
            {
                merkin2Aakkonen = 0;
            }
            else
            {
                merkin2Aakkonen++;
            }

        }
        else if (paikka == 3)
        {
            if (merkin3Aakkonen == aakkoset.Length - 1)
            {
                merkin3Aakkonen = 0;
            }
            else
            {
                merkin3Aakkonen++;
            }
        }

    }

    //Jos kirjain index on 0, hyppää aakkos listan loppuun, muuten scrollaa kirjaimia taaksepäin
    private void seuraavaKirjainPienempi()
    {
        if (paikka == 1)
        {
            if (merkin1Aakkonen == 0)
            {
                merkin1Aakkonen = aakkoset.Length - 1;
            }
            else merkin1Aakkonen--;
        }
        else if (paikka == 2)
        {
            if (merkin2Aakkonen == 0)
            {
                merkin2Aakkonen = aakkoset.Length - 1;
            }
            else merkin2Aakkonen--;
        }
        else if (paikka == 3)
        {
            if (merkin3Aakkonen == 0)
            {
                merkin3Aakkonen = aakkoset.Length - 1;
            }
            else merkin3Aakkonen--;
        }
        else if (paikka == 4)
        {
            paikka = 2;
        }

    }
    //Muuttaa kaikki kirjaimet mustaksi, jonka jälkeen
    //katsoo, missä kirjainslotissa mennään ja muuttaa sen valkoiseksi
    private void tarkistaVari()
    {
        merkki1.color = Color.white;
        merkki2.color = Color.white;
        merkki3.color = Color.white;
        if (paikka == 1)
        {
            merkki1.color = Color.yellow;
        }
        else if (paikka == 2)
        {
            merkki2.color = Color.yellow;
        }
        else if (paikka == 3)
        {
            merkki3.color = Color.yellow;
        }
    }
}