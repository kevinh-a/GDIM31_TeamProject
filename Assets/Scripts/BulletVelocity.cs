using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BulletVelocity : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    [SerializeField]
    private GameObject bulletParticles;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Benemy enemy = collision.GetComponent<Benemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(20);
        }
        Instantiate(bulletParticles,transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
 