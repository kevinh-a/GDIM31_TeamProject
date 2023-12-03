using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Benemy : MonoBehaviour
{
    public float health = 20;
    public float speed = 20;

    [SerializeField]
    private GameObject deathParticles;

    Rigidbody2D rb; 

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0 )
        {
            Instantiate(deathParticles, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   /* private void FixedUpdate()
    {
        rb.velocity = Vector2(speed, rb.velocity.y);
    }
   */
}

