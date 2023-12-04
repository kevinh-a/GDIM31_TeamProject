using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private int lives;
    // Start is called before the first frame update
    void Start()
    {
        lives = GameStateManager.GetLives();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
