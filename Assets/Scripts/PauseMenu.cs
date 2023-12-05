using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenuObj;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenuObj.SetActive(false);
    }

    void Resume()
    {
        Time.timeScale = 1f;
        pauseMenuObj.SetActive(false);
    }

    void Pause()
    {
        Time.timeScale = 0f;
        pauseMenuObj.SetActive(true);
    }

    void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainestMenu");
    }

    void Quit()
    {
        Application.Quit();
    }
}
