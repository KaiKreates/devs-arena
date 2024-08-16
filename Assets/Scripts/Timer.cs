using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    private bool isRunning;

    void Start()
    {
        // Start the timer when the script starts
        startTime = Time.time;
        isRunning = true;
        ShowTimer(); // Ensure the timer is visible when starting
    }

    void Update()
    {
        if (isRunning)
        {
            // Calculate the elapsed time since the timer started
            float elapsedTime = Time.time - startTime;

            // Calculate minutes, seconds, and milliseconds
            int minutes = (int)(elapsedTime / 60);
            int seconds = (int)(elapsedTime % 60);
            int milliseconds = (int)((elapsedTime * 1000) % 1000);

            // Update the timer text
            timerText.text = string.Format("{0:00}:{1:00}:{2:0000}", minutes, seconds, milliseconds);
        }
    }

    // Call this method to pause the timer and return the final time string
    public string PauseTimer()
    {
        isRunning = false;
        float finalTime = Time.time - startTime;

        // Calculate final minutes, seconds, and milliseconds
        int minutes = (int)(finalTime / 60);
        int seconds = (int)(finalTime % 60);
        int milliseconds = (int)((finalTime * 1000) % 1000);

        // Hide the timer text when paused
        HideTimer();

        // Return the final time as a string
        return string.Format("{0:00}:{1:00}:{2:0000}", minutes, seconds, milliseconds);
    }

    // Call this method to resume the timer
    public void ResumeTimer()
    {
        isRunning = true;
        startTime = Time.time - (Time.time - startTime); // Adjust start time to keep the elapsed time correct
        ShowTimer();
    }

    // Call this method to reset the timer
    public void ResetTimer()
    {
        startTime = Time.time;
        isRunning = true;
        ShowTimer();
    }

    // Method to hide the timer text
    public void HideTimer()
    {
        timerText.gameObject.SetActive(false);
    }

    // Method to show the timer text
    public void ShowTimer()
    {
        timerText.gameObject.SetActive(true);
    }
}
