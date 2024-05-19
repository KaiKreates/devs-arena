using UnityEngine;

public class RockMove : MonoBehaviour
{
    public float verticalAmplitude = 0.5f;  // Height of the floating effect
    public float verticalFrequency = 2f;    // Speed of the floating effect
    public float horizontalAmplitude = 0.5f;  // Width of the oscillation effect
    public float horizontalFrequency = 2f;    // Speed of the oscillation effect

    private Vector3 startPos;
    private float yOffset;
    private float xOffset;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Calculate vertical floating effect
        yOffset = Mathf.Sin(Time.time * verticalFrequency) * verticalAmplitude;

        // Calculate horizontal oscillation effect
        xOffset = Mathf.Sin(Time.time * horizontalFrequency) * horizontalAmplitude;

        // Apply both effects to the rock's position
        transform.position = startPos + new Vector3(xOffset, yOffset, 0);


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
