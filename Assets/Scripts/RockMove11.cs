using UnityEngine;

public class RockMove11 : MonoBehaviour
{
    public float verticalAmplitude = 0.5f;  // Height of the floating effect
    public float verticalFrequency = 2f;    // Speed of the floating effect
    public float horizontalAmplitude = 0.5f;  // Width of the oscillation effect
    public float horizontalFrequency = 2f;    // Speed of the oscillation effect

    private Vector3 startPos;
    private float yOffset;
    private float zOffset; // Changed from xOffset to zOffset for sideways movement

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Calculate vertical floating effect
        yOffset = Mathf.Sin(Time.time * verticalFrequency) * verticalAmplitude;

        // Calculate horizontal oscillation effect
        // Adjust the zOffset calculation to move the rock sideways along the Z-axis
        zOffset = Mathf.Sin(Time.time * horizontalFrequency) * horizontalAmplitude;

        // Apply both effects to the rock's position
        transform.position = startPos + new Vector3(0, yOffset, zOffset); // Changed to (0, yOffset, zOffset)
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = null;
        }
    }
}
