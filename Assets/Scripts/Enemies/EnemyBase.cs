using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField]
    protected int damage; //damage dealt by enemies

    [SerializeField]
    protected int health; //enemy health

    [SerializeField]
    protected float despawnTimer;   //time for enemies to despawn

    [SerializeField]
    private GameObject deathParticles; 

    [SerializeField]
    private AudioClip deathSound;

    protected Rigidbody2D rb;
    protected bool flipped;

    protected float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        flipped = false;
    }

    // Update is called once per frame
    void Update()
    {
        Movement(); //calls each respective enemy's movement

        timer += Time.deltaTime;
        if (timer >= despawnTimer)  //destroy when it reaches a certain time to prevent cluttering
        {
            Destroy(gameObject);    
        }
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform") //some walls are tagged Platform, so flip directions when it runs into that
        {
            transform.Rotate(0, 180, 0);
            flipped = !flipped;
        }

        if (collision.gameObject.tag == "Player") //Deal damage to players when they collide, and then disappear
        {
            //if collides with a player, take damage, but just despawn for now
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            Destroy(gameObject);
            player.Take_Damage(damage);
        }
    }
    public void TakeDamage(int damage) 
    {
        health -= damage;   //Keeping track of health

        //When an enemy has 0 hp, they die
        if (health <= 0)
        {
            Instantiate(deathParticles, transform.position, transform.rotation);
            AudioManager.PlaySFX(deathSound);
            Destroy(gameObject);
        }
    }

    public abstract void Movement();  //for inheriting classes
}
