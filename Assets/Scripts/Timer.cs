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

            // Calculate minutes and seconds
            int minutes = (int)(elapsedTime / 60);
            int seconds = (int)(elapsedTime % 60);

            // Update the timer text
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
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
