using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameStateManager : MonoBehaviour
{
    public static Action OnGameOver;

    [SerializeField]
    private static int lives; //How many lives the player has

    private static GameStateManager _instance;


    void Start()
    {
        //Setup for Singleton
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(_instance);
        }
        else
        {
            if(_instance != this)
            {
                Destroy(gameObject);
            }
        }

        lives = 3;
    }

    //returns the amount of lives the player has
    public int GetLives()
    {
        return lives;
    }

    public static void LoseALife()
    {
        lives--;

        if(lives <= 0)
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
