using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private AudioClip playMusic;

    // Credit to the background image
    // https://www.vecteezy.com/free-vector/ruined-city
    // This Menu Class will mostly consist of buttons for the main menu
    public void NewGameButton()
    {
        //Loads in the first level (for now)
        AudioManager.PlayMusic(playMusic);
        SceneManager.LoadScene("Level_1");
        GameStateManager.SetLives(3);
    }
    
    public void ContinueButton()
    {
        if(PlayerPrefs.HasKey("SavedLevel"))
        {
            AudioManager.PlayMusic(playMusic);
            string load_Level = PlayerPrefs.GetString("SavedLevel");
            GameStateManager.SetLives(PlayerPrefs.GetInt("SavedLives"));
            SceneManager.LoadScene(load_Level);
        }
    }

    // Update is called once per frame
    public void Quit()
    {
        //Quits the game application
        Application.Quit();
    }
}
