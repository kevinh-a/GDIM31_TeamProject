using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField]
    protected int damage;

    [SerializeField]
    protected int health;

    [SerializeField]
    protected float despawnTimer;

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
        Movement();

        timer += Time.deltaTime;
        if (timer >= despawnTimer)
        {
            Destroy(gameObject);
        }
    }

    protected void OnCollisionEnter2D(Collision2D collision)
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
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Instantiate(deathParticles, transform.position, transform.rotation);
            AudioManager.PlaySFX(deathSound);
            Destroy(gameObject);
        }
    }

    public abstract void Movement();
}
