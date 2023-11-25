using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D body;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float boost;

    private Vector3 movement;
    private bool isJumping;

    // Start is called before the first frame update
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        isJumping = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            movement += new Vector3(speed, 0, 0);
            //transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            //body.velocity = Vector2.right * speed;
        }

        if(Input.GetKey(KeyCode.A))
        {
            movement += new Vector3(-speed, 0, 0);
            //transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            //body.velocity = Vector2.left * speed;
        }

        if(Input.GetKey(KeyCode.W) && isJumping == false)
        {
            //transform.position += new Vector3(0, boost * Time.deltaTime, 0);
            movement += new Vector3(0, boost, 0);
            //body.velocity = Vector2.up * speed;
        }
    }

    private void FixedUpdate()
    {
        body.AddForce(movement);
        movement = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            isJumping = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isJumping = true;
        }
    }
}
