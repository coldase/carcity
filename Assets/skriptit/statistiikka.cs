using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class statistiikka : MonoBehaviour
{
    public Text GasTeksti;
    public Text ScoreTeksti;
    public static int gas = 20;
    public static float tieindex = 2f;
    public static float startRoad;
    public static float vaikeusaste = 1f;
    public static int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("decreaseGas", 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        ScoreTeksti.text = "SCORE: "+score.ToString();
        GasTeksti.text = "GAS: "+gas.ToString();
    }
    void decreaseGas()
    {
        if(gas > 0)
        {
            gas -= 1;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            statistiikka.tieindex = 2f;
            statistiikka.gas = 20;
            statistiikka.vaikeusaste = 1f;
            statistiikka.startRoad = 0f;
            statistiikka.score = 0;
        }
    }
}
