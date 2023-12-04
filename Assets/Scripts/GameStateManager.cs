using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameStateManager : MonoBehaviour
{
    public static Action OnGameOver;

    [SerializeField]
    private int starting_Lives; //How many lives the player has

    private static int current_Lives;

    private static GameStateManager _instance;


    void Start()
    {
        //Setup for Singleton
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(_instance);
        }
        else
        {
            if (_instance != this)
            {
                Destroy(gameObject);
            }
        }

        current_Lives = starting_Lives;
    }
    //returns the amount of lives the player has
    public static int GetLives()
    {
        return current_Lives;
    }

    public static void LoseALife()
    {
        current_Lives--;

        if(current_Lives <= 0)
        {
            GameOver();
        }
        else
        {
            Restart();
        }
    }

    // Calls the gameover screen and freezes the moving assets in a scene
    public static void GameOver()
    {
        Time.timeScale = 0f;
        OnGameOver();
    }

    public static void Restart()
    {
        SceneManager.LoadScene("Level_1");
        Time.timeScale = 1f;
    }
}
