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
    protected float enemy_MoveSpeed;

    [SerializeField]
    protected float despawnTimer;

    [SerializeField]
    private GameObject deathParticles;

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

    protected void moveLeft()
    {
        transform.position += new Vector3(-enemy_MoveSpeed * Time.deltaTime, 0f, 0f); //make enemies move left
    }

    protected void moveRight()
    {
        transform.position += new Vector3(enemy_MoveSpeed * Time.deltaTime, 0f, 0f); //make enemies move right
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Instantiate(deathParticles, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public abstract void Movement();
}
