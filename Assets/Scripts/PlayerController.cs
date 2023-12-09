using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    [SerializeField]
    private HealthBar hp;

    //[SerializeField]
    //private Animator animator;

    [SerializeField]
    private AudioClip jumpSound;
    [SerializeField]
    private AudioClip hurtSound;
    [SerializeField]
    private AudioClip healSound;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private bool Is_Walking;
    private bool Is_Idle;
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
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
            AudioManager.PlaySFX(jumpSound);
        }
      //  if (horizontal != Vector2.(KeyCode.A) &&
       // {
         //   animator.SetFloat("Is_Moving", horizontal);
       // }
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * speed, body.velocity.y);
        
      //  animator.SetFloat("Is_Walking", (horizontal));
        //animator.SetFloat("Is_Walking", Mathf.Abs(horizontal));

    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "Platform")
        {
            grounded = true;
        }

        if(collision.gameObject.tag == "Out of Bounds")
        {
            GameStateManager.LoseALife(); //lose a life, reset level
        }

        if(collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        grounded = false;
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
        AudioManager.PlaySFX(hurtSound);
        hp.UpdateHealth();
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
        AudioManager.PlaySFX(healSound);
        hp.UpdateHealth();
    }

}
