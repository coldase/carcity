using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class topScoreScript : MonoBehaviour
{
    private int pisteet;
    public Text top1;
    public Text top2;
    public Text top3;

    private int eka;
    private int toka;
    private int kolmas;

    private void readTop3()
    {
        eka = PlayerPrefs.GetInt("top1");
        toka = PlayerPrefs.GetInt("top2");
        kolmas = PlayerPrefs.GetInt("top3");

    }

    private void tallennaTop3()
    {
        //tallentaa pisteet oikeaan muuttujaan tiedostoon
        if(pisteet > eka)
        {
            PlayerPrefs.SetInt("top1", pisteet);
            PlayerPrefs.SetInt("top2", eka);
            PlayerPrefs.SetInt("top3", toka);
        }
        else if (pisteet > toka)
        {
            PlayerPrefs.SetInt("top2", pisteet);
            PlayerPrefs.SetInt("top3", toka);
        }
        else if (pisteet > kolmas)
        {
            PlayerPrefs.SetInt("top3", pisteet);
        }
        //tuo oikean listan näytölle (UI)
        readTop3();
    }

    private void paivitaTop3()
    {
        top1.text = eka.ToString();
        top2.text = toka.ToString();
        top3.text = kolmas.ToString();
        tallennaTop3();
    }

    //arpoo pistemäärän, jatkosas tämä tulee muuttujana itse pelistä
    public void randomScore()
    {
        pisteet = Random.Range(1000, 10000);
        Debug.Log("Pisteet: " + pisteet.ToString());

        paivitaTop3();


    }
    
    public void resetTop3()
    {
        //Luodaan oletusarvot
        PlayerPrefs.SetInt("top1", 3000);
        PlayerPrefs.SetInt("top2", 2000);
        PlayerPrefs.SetInt("top3", 1200);
        paivitaTop3();
    }

    // Start is called before the first frame update
    void Start()
    {
        paivitaTop3();
        //luetaan nämä muuttujiin
        readTop3();
    }

    // Update is called once per frame
    void Update()
    {
        //paivitaTop3();    
    }
}
