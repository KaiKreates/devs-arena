using System.Collections;
using UnityEngine;

public class SinkingRock : MonoBehaviour
{
    public float sinkingSpeed = 1.5f;  // Speed at which the rock will sink
    public float delay = 2f;           // Delay before the rock starts sinking

    private bool isSinking = false;    // Flag to check if the rock should start sinking

    void Update()
    {
        if (isSinking)
        {
            // Move the rock downward
            transform.Translate(Vector3.down * sinkingSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the player has landed on the rock
        if (collision.gameObject.CompareTag("Player"))
        {
            // Start the coroutine to delay the sinking
            StartCoroutine(StartSinking());
        }
    }

    private IEnumerator StartSinking()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);
        // Set the flag to true to start sinking
        isSinking = true;
    }
}
