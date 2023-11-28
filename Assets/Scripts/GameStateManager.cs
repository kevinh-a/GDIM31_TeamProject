using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameStateManager : MonoBehaviour
{
    public static Action OnGameOver;

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
    }

    // Update is called once per frame
    public static void GameOver()
    {
        Time.timeScale = 0f;
        OnGameOver();
    }
}
