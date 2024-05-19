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
            int milliseconds = (int)((elapsedTime * 1000) % 1000); // Adjusted for four-digit milliseconds

            // Update the timer text
            timerText.text = string.Format("{0:00}:{1:00}:{2:0000}", minutes, seconds, milliseconds);
        }
    }

    // Call this method to pause the timer
    public void PauseTimer()
    {
        isRunning = false;
    }

    // Call this method to resume the timer
    public void ResumeTimer()
    {
        isRunning = true;
    }

    // Call this method to reset the timer
    public void ResetTimer()
    {
        startTime = Time.time;
       
    }
}
