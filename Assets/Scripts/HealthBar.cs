using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private int lives;

    [SerializeField]
    private Text livesCounter;

    [SerializeField]
    private Image[] heartsSprites;

    private PlayerController playCon;

    // Start is called before the first frame update
    void Start()
    {
        lives = GameStateManager.GetLives();
        CreateHearts(3);
    }

    private void CreateHearts(int numOfHearts)
    {
        for (int i = 0; i < numOfHearts; i++)
        {
            //Instantiate(heartsSprites, transform);
        }
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
        for(int i = 0; i < heartsSprites.Length; i++)
        {
            if( i < playCon.GetCurrentHealth())
            {
                heartsSprites[i].color = Color.red;
            }
            else
            {
                heartsSprites[i].color = Color.black;
            }
        }
    }
}
