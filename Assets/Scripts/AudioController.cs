using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip audioClip; // Audio clip to play when spacebar is pressed

    void Update()
    {
        // Check if the spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Play the audio clip at the current position
            if (audioClip != null)
            {
                AudioSource.PlayClipAtPoint(audioClip, transform.position);
            }
        }
    }
}
