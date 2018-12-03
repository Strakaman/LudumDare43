using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public bool GameOver = false;
    static int latestKills = 0;
    public int kills = 0;
    private static PlayerHealth s_player = null;
    public Text timerText;
    public GameObject GameOverScreen;
    public Text gameOverDetails;
    float startTime = 0;
    public PlayerHealth playerGameObject
    {
        get
        {
            if (s_player == null)
            {
                s_player = FindObjectOfType(typeof(PlayerHealth)) as PlayerHealth;
            }
            return s_player;
        }
    }

    void Start()
    {
        gameOverDetails = GameOverScreen.GetComponentInChildren<Text>();
        kills = 0;
        startTime = Time.time;
    }

    void Update()
    {
        if (!GameOver)
        {
            GameOverScreen.SetActive(false);
        }
        if (latestKills >= 4)
        {
            // play Rampage kill sound
        }
        else if (latestKills >= 3)
        {
            // play triple kill sound
        }
        else if (latestKills >= 2)
        {
            // play double kill
        }
        if (!GameOver)
        {

            string minutes = Mathf.Floor((Time.time - startTime) / 60).ToString("00");
            string seconds = ((Time.time - startTime) % 60).ToString("00");

            timerText.text = "Time Alive: " + string.Format("{0}:{1}", minutes, seconds);
        }
    }

    public void DoGameOver()
    {
        GameOver = true;
        GameOverScreen.SetActive(true);
        string minutes = Mathf.Floor((Time.time - startTime) / 60).ToString("00");
        string seconds = ((Time.time - startTime) % 60).ToString("00");

        
        gameOverDetails.text = "YOU DIED!\nTotal Kills: " + kills+"\nTime Alive: " + string.Format("{0}:{1}", minutes, seconds);
        Invoke("LoadMenuScene", 5f);

    }


    void LoadMenuScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    #region instance
    private static GameController s_Instance = null;
    public static GameController instance
    {
        get
        {
            if (s_Instance == null)
            {
                s_Instance = FindObjectOfType(typeof(GameController)) as GameController;
            }

            if (s_Instance == null)
            {
                Debug.LogWarning("Could not locate a GameController object!");
            }

            return s_Instance;
        }
    }

    public void UpdateKillCounter()
    {
        ++latestKills;
        int comboSeconds = 3;
        Invoke("ResetKillCounter", comboSeconds);
    }

    void ResetKillCounter()
    {
        --latestKills;
    }
    #endregion
}


