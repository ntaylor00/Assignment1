using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void Restart()
    {
        // 1 - Restart the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // 2 - Reset the player's position, reset score counter, respawn prizes
        // Save player's initial position when game starts
        // when respawning simply reposition the player --> initial position
    }
}
