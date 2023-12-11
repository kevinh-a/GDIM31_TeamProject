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
    private float speed; //Player's speed

    [SerializeField]
    private float boost; //Jump force

    [SerializeField]
    private int bulletDmg; //Dmg from each bullet

    [SerializeField]
    private int starting_Health; //determine starting health

    [SerializeField]
    private int current_Health; //Seralized just to be viewed in the editor

    [SerializeField]
    private HealthBar hp;

    //All audioclips used for the player's movements/actions
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
    
    private float horizontal;
    private bool grounded;
    private bool flipped;

    // Start is called before the first frame update
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        current_Health = starting_Health;
        grounded = false;
        flipped = false;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Smoother player movement with Input.GetAxisRaw, credit to https://www.youtube.com/watch?v=K1xZ-rycYY8

        horizontal = Input.GetAxisRaw("Horizontal"); //get horizontal input (A or D / left or right)

        if(Mathf.Abs(horizontal) > 0f)
        {
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) //Allows player to move to the left with A
        {
            if (flipped == false)
            {
                transform.Rotate(0, 180, 0);
                flipped = true;

            }
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) //Allows player to move to the right with D
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
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * speed, body.velocity.y);

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

        if(collision.gameObject.tag == "Win")
        {
            Time.timeScale = 0f;
            GameStateManager.Win();
        }
    }

    //Detects when the player is off the ground, so jumping is disabled
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            grounded = false;
        }
    }

    //Changes the player's speed
    public void AugmentSpeed(float spBoost)
    {
        speed += spBoost;
    }

    //Changes the player's jumpforce
    public void AugmentJump(float jmBoost)
    {
        boost += jmBoost;
    }

    //Changes the bullet damage
    public void AugmentDmg(int dmgBoost)
    {
        bulletDmg += dmgBoost;
    }

    //Returns bullet damage
    public int GetBulletDmg()
    {
        return bulletDmg;
    }

    //Returns starting health
    public int GetStartingHealth()
    {
        return starting_Health;
    }

    //Returns current health
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
        //No more than max hp
        if (current_Health + health > starting_Health)
        {
            current_Health = starting_Health;
        }
        else
        {
            current_Health += health;
        }
        //Plays the heal SFX, and updates the UI health bar
        AudioManager.PlaySFX(healSound);
        hp.UpdateHealth();
    }

}
