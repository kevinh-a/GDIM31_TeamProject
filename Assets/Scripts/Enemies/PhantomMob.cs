using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhantomMob : EnemyBase
{
    [SerializeField]
    private float moveRate;

    [SerializeField]
    private float minX, maxX, minY, maxY;
    public override void Movement()
    {
        timer += Time.deltaTime;

        if (timer > moveRate)
        {
            transform.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            timer = 0;
        }
    }
}
