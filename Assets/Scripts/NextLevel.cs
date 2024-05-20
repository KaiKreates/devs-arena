using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    // Name of the scene to load
    public string sceneName;

    // Condition to check for scene switching
    public bool switchConditionMet = false;

    // Update is called once per frame
    void Update()
    {
        // Check if the condition is met, the Enter key is pressed, and the Level Completed UI is active
        if (switchConditionMet && Input.GetKeyDown(KeyCode.Return) && IsLevelCompletedUIActive())
        {
            // Load the specified scene
            SceneManager.LoadScene(sceneName);
        }
    }

    // Method to check if the Level Completed UI is active
    private bool IsLevelCompletedUIActive()
    {
        // Get the Level Completed UI GameObject
        GameObject levelCompletedUI = GameObject.FindWithTag("LevelCompletedUI");

        // Return true if the UI is active, otherwise false
        return levelCompletedUI != null && levelCompletedUI.activeSelf;
    }
}
