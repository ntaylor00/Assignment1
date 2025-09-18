using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    //Ladder Tutorial
    /*private bool isFacingRight = true;
    //private bool jump = false;
    //private bool jumpHeld = false;
    private bool crouchHeld = false;
    //private bool isUnderPlatform = false;
    private bool isCloseToLadder = false; // true when player near but not on ladder
    private bool climbHeld = false; // true when player press & hold climb button
    private bool hasStartedClimb = false; // so they don't fall off

    private Transform ladder;
    private float vertical = 0f;
    private float climbSpeed = 0.2f;*/

    // Player Movement Video
    private Rigidbody2D rb;

    private float Move;

    public float speed;
    public float jump2;
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;

    bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Player Movement Video
        Move = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(Move * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded()) // && grounded
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump2 * 10));
        }

        //Ladder Tutorial
        /*vertical = Input.GetAxisRaw("Vertical") * climbSpeed;
          
        crouchHeld = (isGrounded() && !isCloseToLadder && Input.GetButton("Crouch")) ? true : false;
        climbHeld = (isCloseToLadder && Input.GetButton("Climb")) ? true : false;
        //FIXME -- animations, remove

        if (climbHeld)
        {
            if (!hasStartedClimb) hasStartedClimb = true;
        }*/
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

    // Ladder Tutorial
    /*private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Ladder"))
        {
            isCloseToLadder = true;
            this.ladder = collision.transform;
        }
    }

void FixedUpdate()
{
    // Climbing
    if(hasStartedClimb && !climbHeld)
    {
        //if(horizontal > 0 || horizontal < 0) ResetClimbing();
    }
    else if(hasStartedClimb && climbHeld)
    {
        float height         = GetComponent<SpriteRenderer>().size.y;
        float topHandlerY    = Half(ladder.transform.GetChild(0).transform.position.y + height);
        float bottomHandlerY = Half(ladder.transform.GetChild(1).transform.position.y + height);
        float transformY     = Half(transform.position.y);
        float transformVY    = transformY + vertical;
 
        if (transformVY > topHandlerY || transformVY < bottomHandlerY)
        {
            ResetClimbing();
        }
        else if (transformY <= topHandlerY && transformY >= bottomHandlerY)
        {
            rigidBody2D.bodyType = RigidbodyType2D.Kinematic;
            if (!transform.position.x.Equals(ladder.transform.position.x))
                 transform.position = new Vector3(ladder.transform.position.x,transform.position.y,transform.position.z);
 
            Vector3 forwardDirection = new Vector3(0, transformVY, 0); 
            Vector3 newPos = Vector3.zero;
            if (vertical > 0)
                newPos = transform.position + forwardDirection * Time.deltaTime * climbSpeed;
            else if(vertical < 0)
                newPos = transform.position - forwardDirection * Time.deltaTime * climbSpeed;
            if (newPos != Vector3.zero) rigidBody2D.MovePosition(newPos);
        }
    }
}
    public static float Half(float value)
    {
        return Mathf.Floor(value) + 0.5f;
    }

    private void ResetClimbing()
    {
        if(hasStartedClimb)
        {
            hasStartedClimb = false;
            rigidBody2D.bodyType = RigidbodyType2D.Dynamic;
            transform.position = new Vector3(transform.position.x, Half(transform.position.y),transform.position.z);
        }
    }*/

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
