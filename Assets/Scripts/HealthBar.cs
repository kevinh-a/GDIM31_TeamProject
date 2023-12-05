using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private int lives;

    [SerializeField]
    private Text livesCounter;

    // Start is called before the first frame update
    void Start()
    {
        lives = GameStateManager.GetLives();
    }

    // Update is called once per frame
    void Update()
    {
        livesCounter.text = "Lives: " + lives;
    }

    public void UpdateLives()
    {
        //Called in different classes whenever a life is updated
        lives = GameStateManager.GetLives();
    }

    public void UpdateHealth()
    {
        
    }
}
