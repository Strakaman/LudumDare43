using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool GameOver = false;
    static int latestKills = 0;
    private static PlayerHealth s_player = null;

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

    void Update()
    {
        if (latestKills >= 4)
        {
            // play Rampage kill sound
        }
        if (latestKills >= 3)
        {
            // play triple kill sound
        }
        if (latestKills >= 2)
        {
            // play double kill
        }
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

    public static void UpdateKillCounter()
    {
        ++latestKills;
        //int comboSeconds = 3;
        //Invoke("ResetKillCounter", comboSeconds);
    }

    void ResetKillCounter()
    {
        latestKills = 0;
    }
    #endregion
}


