<<<<<<< Updated upstream
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
=======
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
>>>>>>> Stashed changes
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
        GameStateManager.GameOver();
    }

    public static void BackToMenu()
    {
        SceneManager.LoadScene("MainestMenu");
    }
<<<<<<< Updated upstream
}
=======
}
>>>>>>> Stashed changes
