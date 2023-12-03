using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowUp : PowerUpBase
{
    //adjust this variable in order to change how much hp is increased per health powerup
    [SerializeField]
    private int healthAdd;

    public override void Apply(PlayerController player)
    {
        player.AddHealth(healthAdd);
    }
}
