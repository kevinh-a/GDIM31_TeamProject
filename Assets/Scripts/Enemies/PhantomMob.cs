using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhantomMob : EnemyBase
{
    [SerializeField]
    private float speed;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public override void Movement()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
