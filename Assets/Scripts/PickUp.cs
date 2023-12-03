using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private PowerUpBase powerUp;

    public void Initializing(PowerUpBase power)
    {
        powerUp = power;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();

        //If the the object that was triggered isn't the player, then it will not 
        if(player != null)
        {
            powerUp.Apply(player);
            Destroy(gameObject);
        }
    }
}
