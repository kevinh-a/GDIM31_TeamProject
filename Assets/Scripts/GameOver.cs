using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
 
    void Awake()
    {
        //subscribes the action in GameStateManager to GameOver
        GameStateManager.OnGameOver += Open;
        gameObject.SetActive(false);
    }

    public void OnDestroy()
    {
        GameStateManager.OnGameOver -= Open;
    }

    private void Open()
    {
        gameObject.SetActive(true);
    }

    public void Restart()
    {
        //Turns off the canvas (Game over screen)
        gameObject.SetActive(false);
        //Calls GameStateManager's Restart function
        GameStateManager.Restart();
        GameStateManager.SetLives(3);
    }

    public static void BackToMenu()
    {
        //Sets the timescale back to normal
        Time.timeScale = 1f;
        //Loads the main menu scene
        SceneManager.LoadScene("MainestMenu");
    }
}
