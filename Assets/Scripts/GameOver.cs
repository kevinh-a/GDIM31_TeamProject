using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        //subscribes the action in GameStateManager to GameOver
        GameStateManager.OnGameOver += Open;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
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
        gameObject.SetActive(false);
        Time.timeScale = 1f;
        GameStateManager.GameOver();
    }

    public static void BackToMenu()
    {
        SceneManager.LoadScene("MainestMenu");
    }
}
