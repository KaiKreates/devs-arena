using UnityEngine;
using UnityEngine.UI;

public class TimeDisplay : MonoBehaviour
{
    public Text timeText; // Reference to the Text component where the time will be displayed

    private float startTime; // Time when the player started the level
    private bool levelCompleted = false; // Flag to track if the level is completed

    void Start()
    {
        // Record the starting time when the level starts
        startTime = Time.time;
    }

    void Update()
    {
        // If the level is completed, update the time display
        if (levelCompleted)
        {
            // Calculate the time taken by subtracting the start time from the current time
            float elapsedTime = Time.time - startTime;

            // Convert the elapsed time to minutes, seconds, and milliseconds
            int minutes = Mathf.FloorToInt(elapsedTime / 60f);
            int seconds = Mathf.FloorToInt(elapsedTime % 60f);
            int milliseconds = Mathf.FloorToInt((elapsedTime * 1000f) % 1000f);

            // Update the time display text
            timeText.text = "Time Record: " + minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("0000");
        }
    }

    // Call this method to indicate that the level is completed
    public void LevelCompleted()
    {
        levelCompleted = true;
    }
}
