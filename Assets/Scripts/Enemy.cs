using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int damage;

    [SerializeField]
    private int health;

    [SerializeField]
    private float enemy_MoveSpeed;

    [SerializeField]
    private GameObject deathParticles;

    private Rigidbody2D rb;
    private bool flipped;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        flipped = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(flipped == false)
        {
            moveLeft();
        }
        else
        {
            moveRight();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            transform.Rotate(0, 180, 0);
            flipped = !flipped;
        }

        if(collision.gameObject.tag == "Player")
        {
            //if collides with a player, take damage, but just despawn for now
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            player.Take_Damage(damage);

            Destroy(gameObject);
        }
        
        //if(collision.gameObject.tag == "Bullet")
        //{
        //    TakeDamage(20);
        //}
    }

    private void moveLeft()
    {
        transform.position += new Vector3(-enemy_MoveSpeed * Time.deltaTime, 0f, 0f); //make enemies move left
    }

    private void moveRight()
    {
        transform.position += new Vector3(enemy_MoveSpeed * Time.deltaTime, 0f, 0f); //make enemies move right
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            //Instantiate(deathParticles, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
