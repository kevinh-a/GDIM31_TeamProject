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
        //Loads the nextindexed scene
        //SceneManager.LoadScene();
    }

    // Update is called once per frame
    public void Quit()
    {
        //Quits the game application
        Application.Quit();
    }
}
