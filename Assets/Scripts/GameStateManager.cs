using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager instance;
    // Start is called before the first frame update
    void Start()
    {
        //sets up a singleton
        if(instance != null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    public static void GameOver()
    {
        //Causes gameobjects to stop moving after the game is done
        Time.timeScale = 0f;

    }
}
