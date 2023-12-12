using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenuObj;
    [SerializeField]
    private AudioClip mainMenuMusic;

    //Tells the game if the game is already paused
    private static bool gameIsPaused;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenuObj.SetActive(false);
        gameIsPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //If the game is paused and esc is pressed, resume the game
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        //Resumes time, and hides the pause screen
        Time.timeScale = 1f;
        pauseMenuObj.SetActive(false);
        gameIsPaused = false;
    }

    public void Pause()
    {
        //stops time, and shows the pause screen
        Time.timeScale = 0f;
        pauseMenuObj.SetActive(true);
        gameIsPaused = true;
    }

    public void BackToMenu()
    {
        //Saves game, resumes time, and heads back to the main menu
        GameStateManager.SaveGame();
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainestMenu");
        AudioManager.PlayMusic(mainMenuMusic);
    }

    public void PauseQuit()
    {
        //Saves game, then quits the application
        GameStateManager.SaveGame();
        Application.Quit();
    }
}
