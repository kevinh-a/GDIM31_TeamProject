using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int damage;

    [SerializeField]
    private float enemy_MoveSpeed; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-enemy_MoveSpeed * Time.deltaTime, 0f, 0f); //make enemies move left, towards the player
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //if collides with a player, take damage, but just despawn for now
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            player.Take_Damage(damage);

            Destroy(gameObject);
        }
    }
}
