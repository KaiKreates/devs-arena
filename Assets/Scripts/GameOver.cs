using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;

    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }
}
