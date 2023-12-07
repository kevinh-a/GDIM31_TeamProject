using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Credit to the background image
    // https://www.vecteezy.com/free-vector/ruined-city
    // This Menu Class will mostly consist of buttons for the main menu
    public void PlayButton()
    {
        //Loads in the first level (for now)
        SceneManager.LoadScene("Level_1");
        GameStateManager.SetLives(3);
    }

    // Update is called once per frame
    public void Quit()
    {
        //Quits the game application
        Application.Quit();
    }
}
