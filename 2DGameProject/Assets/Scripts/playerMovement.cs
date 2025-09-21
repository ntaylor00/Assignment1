using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // Player Movement Video
    private Rigidbody2D rb;

    private float Move;

    public float speed;
    public float jump;
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;

    private Animator anim;

    private bool isFacingRight;

    public Collectible cc;
    //public LifeCount extraLife;

    bool grounded;

    bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        isFacingRight = true;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            return;
        }
            
        else
        {
            // Player Movement Video
            Move = Input.GetAxisRaw("Horizontal");

            rb.velocity = new Vector2(Move * speed, rb.velocity.y);

            if (Input.GetButtonDown("Jump") && isGrounded()) // && grounded
            {
                rb.AddForce(new Vector2(rb.velocity.x, jump * 10));
            }

            if(Move != 0)
            {
                anim.SetBool("isRunning", true);
            }
            else
            {
                anim.SetBool("isRunning", false);
            }

            anim.SetBool("isJumping", !isGrounded());

            if(!isFacingRight && Move > 0)
            {
                // If looking left but moving right, flip
                Flip();
            }
            else if (isFacingRight && Move < 0)
            {
                // If looking right but moving left, flip
                Flip();
            }
        }
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    // Player Movement Video
    public bool isGrounded()
    {
        if(Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
    }

    public void Die()
    {
        isDead = true;
        FindObjectOfType<LevelManager>().DeathMenu();
    }

    public void ResetPlayer()
    {
        /*Move = 0;
        speed = 0;
        jump = 0;*/
        isDead = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Prize"))
        {
            Destroy(other.gameObject);
            cc.coinCount++;
        }
        if (other.gameObject.CompareTag("ExtraLife"))
        {
            // Destroy green coin and add one to life count
            Destroy(other.gameObject);
            FindObjectOfType<LifeCount>().AddLife();
        }
    }

    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (other.gameObject.CompareTag("Ground"))
    //     {
    //         Vector3 normal = other.GetContact(0).normal;
    //         if(normal == Vector3.up)
    //         {
    //             grounded = true;
    //         }
    //     }
    // }

    // private void OnCollisionExit2D(Collision2D other)
    // {
    //     if (other.gameObject.CompareTag("Ground"))
    //     {
    //         grounded = false;
    //     }
    // }
}
