using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BulletVelocity : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private int bullet_Damage;

    [SerializeField]
    private AudioClip bullet_sound;
     
    private Rigidbody2D rb;

    [SerializeField]
    private GameObject bulletParticles;
    public GameObject bulletPrefab;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        AudioManager.PlaySFX(bullet_sound);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBase enemy = collision.GetComponent<EnemyBase>();

        if (enemy != null)
        {
            enemy.TakeDamage(bullet_Damage);
        }
        //Instantiate(bulletParticles, transform.position, transform.rotation);
        Destroy(gameObject);

    }
}

 