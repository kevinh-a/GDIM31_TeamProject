using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling_Objects : MonoBehaviour
{
    Rigidbody2D rb;
    private object col;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
       // if (!col.gameObject.name.Equals("Player"))
        //    return;
        //rb.isKinematic = false;
    }

}
