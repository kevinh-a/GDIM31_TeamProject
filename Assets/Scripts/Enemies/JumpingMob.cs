using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingMob : EnemyBase
{
    [SerializeField]
    private float enemy_JumpForce;

    private bool grounded = false;
    public override void Movement()
    {
        if (grounded == true)
        {
            rb.velocity = new Vector2(0, enemy_JumpForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            grounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            grounded = false;
        }
    }
}
