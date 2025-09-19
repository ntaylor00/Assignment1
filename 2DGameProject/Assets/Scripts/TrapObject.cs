using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class TrapObject : MonoBehaviour
{
    public void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            FindObjectOfType<LifeCount>().LoseLife();
        }
    }
}
