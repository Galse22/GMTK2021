using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GeneralScriptGManager : MonoBehaviour
{
    public SceneRandomizer sceneRandomizer;
    [Header("Hideable")]
    public Text timerText;
    float timePassed;
    float time20 = 20f;
    string timeString;
    public bool frozen;

    private GameObject previousGO;

    int highScore;
    int score;
    Text highScoreTXT;

    private void Awake() {
        previousGO = GameObject.FindWithTag("GGameManager");
        Destroy (previousGO);
        gameObject.tag = "GGameManager";
        DontDestroyOnLoad(this.gameObject);
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreTXT = GameObject.FindWithTag("HStxt").GetComponent<Text>();
        highScoreTXT.text = "HIGH SCORE: " + highScore;
        GameObject menuManager = GameObject.FindWithTag("MenuManager");
        menuManager.GetComponent<MenuManagerS>().sceneRandomizer = sceneRandomizer;
    }

    void Update()
    {
        if(!frozen)
        {
            timePassed += Time.deltaTime;
            time20 -= timePassed;
            if(time20 <= 0)
            {
                if(highScore < score)
                {
                    PlayerPrefs.SetInt("HighScore", score);
                    SceneManager.LoadScene(2);
                    frozen = true;
                }
                else
                {
                    SceneManager.LoadScene(1);
                }
            }
            else if(time20 > 0)
            {
                if(timerText != null)
                {
                    timeString = time20.ToString("0.00");
                    timerText.text = timeString + " - " + score;
                }
                time20 = 20f;
            }
        }
    }
    public void IncreaseScore()
    {
        score++;
    }

}
