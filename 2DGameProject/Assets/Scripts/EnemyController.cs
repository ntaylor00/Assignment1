using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : PhysicsBase
{
    // Start is called before the first frame update
    void Start()
    {
        desiredx = 3;
        /*
        if VerticalEnemy
        desiredy = 3;
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void CollideHorizontal(Collider2D other)
    {
        desiredx = -desiredx; // If it collides, move opposite direction
    }
    //if VerticalEnemy -- delete
    /*public override void CollideVertical(Collider2D other)
    {
        desiredy = -desiredy;
    }*/
}