using System.Collections;
using UnityEngine;

public class SharkAudioController : MonoBehaviour
{
    public AudioClip moveAudioClip; // Audio clip to play when the shark is moving
    public AudioClip collisionAudioClip; // Audio clip to play when the shark collides with a rock

    private Vector3 lastPosition; // To track the last position of the shark
    private bool isMoving; // To check if the shark is moving
    private bool isPlayingAudio; // To check if the audio is already being played

    void Start()
    {
        lastPosition = transform.position; // Initialize the last position
        isPlayingAudio = false;
    }

    void Update()
    {
        // Check if the shark has moved
        if (transform.position != lastPosition)
        {
            if (!isMoving)
            {
                isMoving = true;
                if (!isPlayingAudio)
                {
                    StartCoroutine(PlayMoveAudioRepeatedly());
                }
            }
        }
        else
        {
            isMoving = false;
            isPlayingAudio = false; // Stop playing audio if shark is not moving
        }

        // Update the last position
        lastPosition = transform.position;
    }

    IEnumerator PlayMoveAudioRepeatedly()
    {
        isPlayingAudio = true;
        while (isMoving)
        {
            // Play the audio clip at the shark's position
            if (moveAudioClip != null)
            {
                AudioSource.PlayClipAtPoint(moveAudioClip, transform.position);
            }

            // Wait for 5 seconds before playing the audio again
            yield return new WaitForSeconds(5f);
        }
        isPlayingAudio = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            // Play the collision audio clip at the shark's position
            if (collisionAudioClip != null)
            {
                AudioSource.PlayClipAtPoint(collisionAudioClip, transform.position);
            }
        }
    }
}
