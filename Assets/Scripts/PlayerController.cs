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
    private int starting_Health; //determine starting health

    [SerializeField]
    private int current_Health; //Seralized just to be viewed in the editor

    private float horizontal;
    private bool grounded;
    private bool flipped;

    // Start is called before the first frame update
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        current_Health = starting_Health;
        grounded = true;
        flipped = false;
    }

    // Update is called once per frame
    private void Update()
    {
        //Smoother player movement with Input.GetAxisRaw, credit to https://www.youtube.com/watch?v=K1xZ-rycYY8

        horizontal = Input.GetAxisRaw("Horizontal"); //get horizontal input (A or D / left or right)

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (flipped == false)
            {
                transform.Rotate(0, 180, 0);
                flipped = true;
            }
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (flipped == true)
            {
                transform.Rotate(0, 180, 0);
                flipped = false;
            }
        }

        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)) && grounded == true) //allows jump if player is on ground
        {
            body.velocity = new Vector2(body.velocity.x, boost);
        }

    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * speed, body.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision) //checking if player is on the ground
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

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.tag == "Out of Bounds")
        {
            GameStateManager.LoseALife(); //lose a life, reset level
        }

        if(collision.gameObject.tag == "Finish")
        {
            //go next level
        }
    }

    public void AugmentSpeed(float spBoost)
    {
        speed += spBoost;
    }

    public void AugmentJump(float jmBoost)
    {
        boost += jmBoost;
    }

    public int GetStartingHealth()
    {
        return starting_Health;
    }

    public int GetCurrentHealth()
    {
        return current_Health;
    }

    public void Take_Damage(int damage)
    {
        current_Health -= damage;

        if(current_Health <= 0)
        {
            GameStateManager.LoseALife(); //lose a life, reset level
        }
    }

    public void AddHealth(int health)
    {
        if (current_Health + health > starting_Health)
        {
            current_Health = starting_Health;
        }
        else
        {
            current_Health += health;
        }
    }
}
