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
    public GameObject winScreen;

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

        current_Lives = _instance.starting_Lives;
    }

    void Start()
    {
        //Plays the menu music
        AudioManager.PlayMusic(menuMusic);
    }

    public static void NewGame()
    {
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
        Time.timeScale = 0f;
        OnGameOver();
    }

    //returns the amount of lives the player has
    public static int GetLives()
    {
        return current_Lives;
    }

    //Called when a player loses a life
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

    //Called when the amount of lives needs to be changed
    public static void SetLives(int lives)
    {
        current_Lives = lives;
    }

    public static void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        AudioManager.PlayMusic(_instance.gameMusic);
    }

    public static void SaveGame()
    {
        //Saves the current level and amount of lives
        string active_Level = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("SavedLevel", active_Level);
        PlayerPrefs.SetInt("SavedLives", GetLives());
    }

    public static void Win()
    {
        //Shows the winning screen when this method is triggered
        _instance.winScreen.SetActive(true);
        Time.timeScale = 0f;
    }
}
