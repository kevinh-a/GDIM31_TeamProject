using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameStateManager : MonoBehaviour
{
    public static Action OnGameOver;

    [SerializeField]
    private List<string> Levels = new List<string>();

    [SerializeField]
    private int starting_Lives; //How many lives the player has

    [SerializeField]
    private AudioClip lossOfLife;
    [SerializeField]
    private AudioClip deathSound;
    [SerializeField]
    private AudioClip gameMusic;
    [SerializeField]
    private AudioClip menuMusic;

    private static int current_Lives;

    private static GameStateManager _instance;

    enum GameState
    {
        Menu,
        Playing,
        Paused,
        GameOver
    }

    private static GameState current_State;
    void Awake()
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

        //Plays the menu music
        AudioManager.PlayMusic(menuMusic);
        current_Lives = _instance.starting_Lives;
    }

    public static void NewGame()
    {
        current_State = GameState.Playing;
        current_Lives = _instance.starting_Lives;
        if(_instance.Levels.Count > 0)
        {
            SceneManager.LoadScene(_instance.Levels[0]);
        }
        //Plays the game's music
        AudioManager.PlayMusic(_instance.gameMusic);
    }

    // Calls the gameover screen and freezes the moving assets in a scene
    public static void GameOver()
    {
        current_State = GameState.GameOver;
        Time.timeScale = 0f;
        OnGameOver();
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
            AudioManager.PlaySFX(_instance.deathSound);
            GameOver();
        }
        else
        {
            AudioManager.PlaySFX(_instance.lossOfLife);
            Restart();
        }
    }

    public static void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        AudioManager.PlayMusic(_instance.gameMusic);
    }
}
