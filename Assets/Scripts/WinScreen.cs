using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public void Awake()
    {
        gameObject.SetActive(false);
    }

    //Heads back to the main menu, and hides the win screen
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainestMenu");
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
