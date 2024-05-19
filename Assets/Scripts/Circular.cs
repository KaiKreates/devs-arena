using UnityEngine;

public class Circular : MonoBehaviour
{
    public float radius = 2.5f; // Radius of the circular path
    public float speed = 1f; // Speed of rotation in degrees per second

    private Vector3 axisPosition;

    void Start()
    {
        // Set the axis position at a fixed distance from the center of the circle
        axisPosition = transform.position + Vector3.forward * radius;
    }

    void Update()
    {
        // Calculate the current angle based on time and speed
        float angle = Time.time * speed;

        // Calculate the position on the circle based on the angle
        Vector3 circlePosition = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;

        // Move the rock along the circle relative to the fixed axis position
        transform.position = axisPosition + circlePosition;
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
