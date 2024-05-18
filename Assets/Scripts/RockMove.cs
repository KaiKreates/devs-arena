using UnityEngine;

public class RockMove : MonoBehaviour
{
    public float verticalAmplitude = 0.5f;  // Height of the floating effect
    public float verticalFrequency = 2f;    // Speed of the floating effect
    public float horizontalAmplitude = 0.5f;  // Width of the oscillation effect
    public float horizontalFrequency = 2f;    // Speed of the oscillation effect

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Calculate vertical floating effect
        float yOffset = Mathf.Sin(Time.time * verticalFrequency) * verticalAmplitude;

        // Calculate horizontal oscillation effect
        float xOffset = Mathf.Sin(Time.time * horizontalFrequency) * horizontalAmplitude;

        // Apply both effects to the rock's position
        transform.position = startPos + new Vector3(xOffset, yOffset, 0);
    }
}
