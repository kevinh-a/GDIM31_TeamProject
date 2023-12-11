using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingMob : EnemyBase
{
    [SerializeField]
    private float enemy_MoveSpeed; //speed of the walking enemies

    public override void Movement()
    {
        if (flipped == false)   //works with the EnemyBase's collision for walls
        {
            MoveLeft();
        }
        else
        {
            MoveRight();
        }
    }

    //Moves to the left
    private void MoveLeft()
    {
        transform.position += new Vector3(-enemy_MoveSpeed * Time.deltaTime, 0f, 0f); //make enemies move left
    }

    //Moves to the right
    private void MoveRight()
    {
        transform.position += new Vector3(enemy_MoveSpeed * Time.deltaTime, 0f, 0f); //make enemies move right
    }
}