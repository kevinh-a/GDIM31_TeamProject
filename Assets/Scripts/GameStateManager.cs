<<<<<<< Updated upstream
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameStateManager : MonoBehaviour
{
    public static Action OnGameOver;
    private int lives; //How many lives the player has

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
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameStateManager : MonoBehaviour
{
    public static Action OnGameOver;
    private int lives; //How many lives the player has

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
>>>>>>> Stashed changes
            if(_instance != this)
            {
                Destroy(gameObject);
            }
<<<<<<< Updated upstream
        }
        lives = 3;
    }

    //returns the amount of lives the player has
    public int GetLives()
    {
        return lives;
    }

    public void LoseALife()
    {
=======
        }
        lives = 3;
    }

    //returns the amount of lives the player has
    public int GetLives()
    {
        return lives;
    }

    public void LoseALife()
    {
>>>>>>> Stashed changes
        lives--;
        if(lives == 0)
        {
            GameOver();
        }
<<<<<<< Updated upstream
    }

    // Calls the gameover screen and freezes the moving assets in a scene
    public static void GameOver()
    {
        Time.timeScale = 0f;
        OnGameOver();
    }

}
=======
    }

    // Calls the gameover screen and freezes the moving assets in a scene
    public static void GameOver()
    {
        Time.timeScale = 0f;
        OnGameOver();
    }

}
>>>>>>> Stashed changes
