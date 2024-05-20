using System.Collections;
using UnityEngine;

public class RockMove : MonoBehaviour
{
    public float verticalAmplitude = 0.5f;
    public float verticalFrequency = 2f;
    public float horizontalAmplitude = 0.5f;
    public float horizontalFrequency = 2f;
    public float forwardAmplitude = 0.5f;
    public float forwardFrequency = 2f;

    private Vector3 startPos;
    private float yOffset, xOffset, zOffset;
    public float startDelay;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        StartCoroutine(MoveRock());
    }

    IEnumerator MoveRock()
    {
        yield return new WaitForSeconds(startDelay);

        yOffset = Mathf.Sin(Time.time * verticalFrequency) * verticalAmplitude;

        xOffset = Mathf.Sin(Time.time * horizontalFrequency) * horizontalAmplitude;

        zOffset = Mathf.Sin(Time.time * forwardFrequency) * forwardAmplitude;

        // Apply all effects to the rock's position
        transform.position = startPos + new Vector3(xOffset, yOffset, zOffset);

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
