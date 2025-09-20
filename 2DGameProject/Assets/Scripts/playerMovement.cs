using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public Collectible pr;

    bool grounded;

    bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
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
        }
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
        SceneManager.LoadScene("DeathMenu");
        //FindObjectOfType<DeathMenu>().DeathMenu();
        //FindObjectOfType<LevelManager>().Restart();
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
            pr.coinCount++;
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
