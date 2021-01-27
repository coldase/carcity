using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class topScoreScript : MonoBehaviour
{
    public GameObject toggleScore;
    public GameObject toggleInput;

    public GameObject toggleSaveBtn;

    public Text youScoredText;
    public static int youScored;

    private int pisteet;
    public Text top1;
    public Text top2;
    public Text top3;

    public Text top1_nimi;
    public Text top2_nimi;
    public Text top3_nimi;

    private int eka;
    private int toka;
    private int kolmas;

    private string ekaNimi;
    private string tokaNimi;
    private string kolmasNimi;

    public Text merkki1;
    public Text merkki2;
    public Text merkki3;
    private int paikka;
    private int merkin1Aakkonen;
    private int merkin2Aakkonen;
    private int merkin3Aakkonen;

    private string[] aakkoset = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
    private int onkoLista;


    private void readTop3()
    {
        eka = PlayerPrefs.GetInt("top1_score");
        toka = PlayerPrefs.GetInt("top2_score");
        kolmas = PlayerPrefs.GetInt("top3_score");

        ekaNimi = PlayerPrefs.GetString("top1_nimi");
        tokaNimi = PlayerPrefs.GetString("top2_nimi");
        kolmasNimi = PlayerPrefs.GetString("top3_nimi");

    }

    private void tallennaTop3()
    {
        //tallentaa pisteet oikeaan muuttujaan tiedostoon
        if (pisteet > eka)
        {
            PlayerPrefs.SetInt("top1_score", pisteet);
            PlayerPrefs.SetInt("top2_score", eka);
            PlayerPrefs.SetInt("top3_score", toka);

            PlayerPrefs.SetString("top1_nimi", ekaNimi);
            PlayerPrefs.SetString("top2_nimi", tokaNimi);
            PlayerPrefs.SetString("top3_nimi", kolmasNimi);
        }
        else if (pisteet > toka)
        {
            PlayerPrefs.SetInt("top2", pisteet);
            PlayerPrefs.SetInt("top3", toka);

            PlayerPrefs.SetString("top2_nimi", ekaNimi);
            PlayerPrefs.SetString("top3_nimi", tokaNimi);
        }
        else if (pisteet > kolmas)
        {
            PlayerPrefs.SetInt("top3", pisteet);
            PlayerPrefs.SetString("top3_nimi", ekaNimi);
        }
        //tuo oikean listan näytölle (UI)
        readTop3();
    }

    private void paivitaTop3()
    {
        readTop3();
        top1.text = eka.ToString();
        top2.text = toka.ToString();
        top3.text = kolmas.ToString();

        top1_nimi.text = ekaNimi.ToString();
        top2_nimi.text = tokaNimi.ToString();
        top3_nimi.text = kolmasNimi.ToString();

        if(youScored > kolmas){
            youScoredText.text = "Your Score was " + youScored.ToString();
            toggleSaveBtn.SetActive(true); 

        }

        //tallennaTop3();
    }

    //arpoo pistemäärän, jatkosas tämä tulee muuttujana itse pelistä
    public void randomScore()
    {
        // pisteet = Random.Range(1000, 10000);
        pisteet = HighScores.topScore;
        youScored = pisteet;
        Debug.Log("Pisteet: " + pisteet.ToString());
        
        paivitaTop3();
        if (pisteet > kolmas)
        {
            Cursor.visible = false;
            toggleScore.SetActive(false);
            toggleInput.SetActive(true);
        }

    }

    public void loadMenuScene(){
        Cursor.visible = true;
        SceneManager.LoadScene("Menu");
    }

    public void resetTop3()
    {
        //Luodaan oletusarvot
        PlayerPrefs.SetInt("top1_score", 0);
        PlayerPrefs.SetInt("top2_score", 0);
        PlayerPrefs.SetInt("top3_score", 0);

        PlayerPrefs.SetString("top1_nimi", "NUL");
        PlayerPrefs.SetString("top2_nimi", "NUL");
        PlayerPrefs.SetString("top3_nimi", "NUL");

        paivitaTop3();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Tsekkaa onko lista olemassa
        onkoLista = PlayerPrefs.GetInt("listaOlemassa");

        //Jos ei, tekee sen, ns dummydata
        if (onkoLista == 0)
        {
            PlayerPrefs.SetString("top1_nimi", "NUL");
            PlayerPrefs.SetString("top2_nimi", "NUL");
            PlayerPrefs.SetString("top3_nimi", "NUL");
            PlayerPrefs.SetInt("top1_score", 0);
            PlayerPrefs.SetInt("top2_score", 0);
            PlayerPrefs.SetInt("top3_score", 0);
            PlayerPrefs.SetInt("listaOlemassa", 1);
        }

        //Laittaa tekstin näytölle
        merkki1.text = aakkoset[merkin1Aakkonen];
        merkki2.text = aakkoset[merkin2Aakkonen];
        merkki3.text = aakkoset[merkin3Aakkonen];
        paikka = 1;

        readTop3();
        paivitaTop3();
        //luetaan nämä muuttujiin
    }

    // Update is called once per frame
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
            if (paikka < 3)
            {
                paikka++;
            }
            else 
                paikka = 1;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (paikka > 1)
            {
                paikka--;
            }
            else paikka = 3;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            tallenna();
            paivitaTop3();
            Cursor.visible = true;
            toggleScore.SetActive(true);
            toggleInput.SetActive(false);
            toggleSaveBtn.SetActive(false);
            youScoredText.text = "";
            youScored = 0;

            // SceneManager.LoadScene(0);
        }
        tarkistaVari();
        paivitaMerkit();
        //paivitaTop3();    
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