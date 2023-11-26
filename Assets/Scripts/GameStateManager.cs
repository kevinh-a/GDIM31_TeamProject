using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameStateManager : MonoBehaviour
{
    public static Action OnGameOver;

    private static GameStateManager _instance;

    // Start is called before the first frame update
    void Start()
    {
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
    }

    public static void GameOver()
    {
        OnGameOver();
    }

    public static void Restart()
    {
        SceneManager.LoadScene(0);
    }

}
