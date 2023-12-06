using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowUp : PowerUpBase
{
    //how much of a speed boost is gained
    [SerializeField]
    private float speedBoost;

    //Duration of power up
    [SerializeField]
    private float duration;

    private float startTime;

    private PlayerController playerCon;

    public override void Apply(PlayerController player)
    {
        //Initializes exact time the powUp is picked up, and gives it to the player char
        startTime = Time.time;
        playerCon = player;
        playerCon.AugmentSpeed(speedBoost);
    }

    private void Update()
    {
        //If the duration has been exceeded in time, end the effects of the speed boost
        if (Time.time - startTime > duration)
        {
            playerCon.AugmentSpeed(-speedBoost);
            Destroy(gameObject);
        }
    }
}
