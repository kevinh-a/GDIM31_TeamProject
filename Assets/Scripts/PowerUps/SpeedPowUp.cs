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

    [SerializeField]
    private AudioClip BoostFX;
    //Needed to prevent nullreferences
    private bool pickedUp = false;

    [SerializeField]
    private PlayerController playerCon;

    public override void Apply(PlayerController player)
    {
        //Initializes exact time the powUp is picked up, and gives it to the player char
        startTime = Time.time;
        playerCon = player;
        playerCon.AugmentSpeed(speedBoost);
        pickedUp = true;
        AudioManager.PlaySFX(BoostFX);
    }

    private void Update()
    {
        if(pickedUp == true)
        {
            //If the duration has been exceeded in time, end the effects of the speed boost
            if (Time.time - startTime > duration)
            {
                playerCon.AugmentSpeed(-speedBoost);
                Destroy(gameObject);
                pickedUp = false;
            }
        }
    }
}
