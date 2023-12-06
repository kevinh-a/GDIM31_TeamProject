using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonMob : EnemyBase
{
    public override void Movement()
    {
        if (flipped == false)
        {
            base.moveLeft();
        }
        else
        {
            base.moveRight();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            transform.Rotate(0, 180, 0);
            flipped = !flipped;
        }

        if (collision.gameObject.tag == "Player")
        {
            //if collides with a player, take damage, but just despawn for now
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            Destroy(gameObject);
            player.Take_Damage(damage);
        }
    }
}