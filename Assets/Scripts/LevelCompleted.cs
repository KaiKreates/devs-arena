using UnityEngine;
using UnityEngine.UI;

public class LevelCompleted : MonoBehaviour
{
    public GameObject levelCompletedUI; // Reference to the Level Completed UI
    public Text finalTimeText; // Reference to the Text component to display the final time

    // Call this method to show the level completed screen and display the final time
    public void ShowScreen(string finalTime)
    {
        finalTimeText.text = "Time Record | " + finalTime;
        levelCompletedUI.SetActive(true); // Display the Level Completed UI
    }
}
