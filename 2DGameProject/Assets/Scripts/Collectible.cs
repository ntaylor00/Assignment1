using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//public enum PickableType { SCORE, ITEM }

public class Collectible : MonoBehaviour
{
    public int coinCount;
    public Text coinText;
    
    void Start()
    {

    }

    void Update()
    {
        coinText.text = "Coins: " + coinCount.ToString() + "/5";
    }
    /*[SerializedField] private PickableType type;
    [SerializedField] private int points = 0;
    [SerializedField] private ItemsSC item = null;
    bool isCollected = false;

    private void Update()
    {
        is (isCollected)
        {
            if (type.Equals(PickableType.SCORE))
            {
                GameManager.instance.addScorePoints(points);
            }
            else if (type.Equals(PickableType.ITEM))
            {
                Inventory.instance.AddItem(item);
            }
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.gameObject.tag.Equals("Player"))
            isCollected = true;
    }*/
    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Add points or other effects here
            Destroy(gameObject); // Remove the collectible from the scene
        }
    }*/
}