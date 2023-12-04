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
    private PlayerController playerCon;

    public override void Apply(PlayerController player)
    {
        //Initializes exact time the powUp is picked up, and gives it to the player char
        startTime = Time.time;
        playerCon = player;
        playerCon.AugmentJump(jumpBoost);
    }

    private void Update()
    {
        //If the duration has been exceeded in time, end the effects
        if(Time.time - startTime > duration)
        {
            playerCon.AugmentJump(-jumpBoost);
            Destroy(gameObject);
        }
    }
}
