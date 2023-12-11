using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDmgPowUp : PowerUpBase
{
    //How much dmg is gained (whole numbers)
    [SerializeField]
    private int dmgBoost;

    //How long the buff is applied
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
        playerCon.AugmentDmg(dmgBoost);
        pickedUp = true;
        AudioManager.PlaySFX(BoostFX);
    }

    private void Update()
    {
        if (pickedUp == true)
        {
            //If the duration has been exceeded in time, end the effects of the dmg boost
            if (Time.time - startTime > duration)
            {
                playerCon.AugmentDmg(-dmgBoost);
                Destroy(gameObject);
                pickedUp = false;
            }
        }
    }
}
