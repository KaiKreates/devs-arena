using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour

{
    void Update()
    {
        // Check if the 'T' key is pressed
        if (Input.GetKeyDown(KeyCode.T))
        {
            RetryLevel();
        }
    }

    public void RetryLevel()
    {
        // Get the current active scene
        Scene currentScene = SceneManager.GetActiveScene();

        // Reload the current scene
        SceneManager.LoadScene(currentScene.name);
    }
}

