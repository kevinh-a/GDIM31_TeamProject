using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPowUp : PowerUpBase
{
    //How much of a jump boost is obtained
    [SerializeField]
    private float jumpBoost;

    //How long the boost will last for
    [SerializeField]
    private float duration;

    private float startTime;

    [SerializeField]
    private AudioClip BoostFX;

    //Needed in order to prevent nullreferences...
    private bool pickedUp = false;

    //This variable causes a lot of null references (until it's grabbed), but this happens
    //In Salmon's video as well, so I assume it's intentional
    [SerializeField]
    private PlayerController playerCon;

    public override void Apply(PlayerController player)
    {
        //Initializes exact time the powUp is picked up, and gives it to the player char
        startTime = Time.time;
        playerCon = player;
        playerCon.AugmentJump(jumpBoost);
        pickedUp = true;
        AudioManager.PlaySFX(BoostFX);
    }

    private void Update()
    {
        //If the duration has been exceeded in time, end the effects
        if(pickedUp == true)
        {
            if (Time.time - startTime > duration)
            {
                playerCon.AugmentJump(-jumpBoost);
                Destroy(gameObject);
                pickedUp = false;
            }
        }
    }
}
