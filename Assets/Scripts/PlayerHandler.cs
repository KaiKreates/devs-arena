using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public GameOver gameOverManager;
    public LevelCompleted levelmanager;
    private Timer timer;

    // Flag to track if the level is completed
    private bool isLevelCompleted = false;

    void Start()
    {
        if (gameOverManager == null)
        {
            gameOverManager = FindObjectOfType<GameOver>();
        }

        if (levelmanager == null)
        {
            levelmanager = FindObjectOfType<LevelCompleted>();
        }

        // Get the Timer component
        timer = FindObjectOfType<Timer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Lava"))
        {
            // Only show Game Over screen if the level is not completed
            if (!isLevelCompleted)
            {
                Debug.Log("Game Over");
                gameOverManager.ShowGameOverScreen();
            }
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            // Set the flag to indicate the level is completed
            isLevelCompleted = true;

            // Level Complete Screen
            Debug.Log("Level Complete");

            // Pause the timer and get the final time
            string finalTime = timer.PauseTimer();

            // Show the level completed screen with the final time
            levelmanager.ShowScreen(finalTime);

            // Hide the timer text
            timer.HideTimer();
        }
    }
}
