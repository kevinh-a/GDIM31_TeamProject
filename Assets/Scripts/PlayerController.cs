using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D body;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float boost;

    [SerializeField]
    private int starting_Health;

    [SerializeField]
    private int current_Health; //Serialized just to be viewed in the editor

    private Vector3 movement;
    private bool grounded;

    // Start is called before the first frame update
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        current_Health = starting_Health;
        grounded = true;
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

        if((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)) && grounded == true)
        {
            movement += new Vector3(0, boost, 0);
            //transform.position += new Vector3(0, boost * Time.deltaTime, 0);
            //body.velocity = Vector2.up * speed;
        }

        if(Input.GetKey(KeyCode.KeypadEnter))
        {
            //do gun stuff
        }
    }

    private void FixedUpdate()
    {
        body.AddForce(movement, ForceMode2D.Force);
        movement = Vector3.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            grounded = false;   
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(Input.GetKey(KeyCode.Space))
        {
            body.AddForce(new Vector2(0, boost));
        }
    }

    public void Take_Damage(int damage)
    {
        current_Health -= damage;

        if(current_Health <= 0)
        {
            //reset level?
        }
    }
}
