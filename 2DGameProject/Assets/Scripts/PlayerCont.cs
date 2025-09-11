using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCont : PhysicsBase
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        desiredx = 0;
        if (Input.GetAxis("Horizontal") > 0) desiredx = 3; // Move right
        if (Input.GetAxis("Horizontal") < 0) desiredx = -3; // Move left

        if (Input.GetButton("Jump") && grounded) velocity.y = 6.5f; // Jump button - only if grounded
    }

    public void Collide(Collider2D other)
    {
        if (other.gameObject.CompareTag("Death"))
        {
            Debug.Log("DED"); //FIXME --> lose a life, if all three lost then restart menu
        }
    }

    public override void CollideHorizontal(Collider2D other)
    {
        Collide(other);
    }

    public override void CollideVertical(Collider2D other)
    {
        Collide(other);
    }
}
