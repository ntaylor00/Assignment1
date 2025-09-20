using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    Vector2 playerInitPosition;

    void Start()
    {
        playerInitPosition = FindObjectOfType<playerMovement>().transform.position;
    }

    public void Restart()
    {
        // 1 - Restart the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // 2 - Reset the player's position, reset score counter, respawn prizes
        // Save player's initial position when game starts
        // when respawning simply reposition the player --> initial position
        // Reset player movement speed
        
        // Reset life count
    }

    public void DeathMenu()
    {
        SceneManager.LoadScene("DeathMenu");
    }

    /*public void Backtrack()
    {
        if(FindObjectOfType<Tilemap> == true)
        {
            // Move back to position before hitting obstacle
            FindObjectOfType<playerMovement>().ResetPlayer();
            FindObjectOfType<playerMovement>().transform.position = playerInitPosition;
            FindObjectOfType<LifeCount>() = 3;
        }
        
    }*/
}
