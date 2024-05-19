using System.Collections;
using UnityEngine;

public class SinkingRock : MonoBehaviour
{
    public float sinkingSpeed = 1.5f;
    public float delay = 2f;

    private bool isSinking = false;    // Flag to check if the rock should start sinking

    void Update()
    {
        if (isSinking)
        {
            transform.Translate(Vector3.down * sinkingSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(StartSinking());
        }
    }

    private IEnumerator StartSinking()
    {
        yield return new WaitForSeconds(delay);
        isSinking = true;
        StartCoroutine(DestroyRock());
    }

    private IEnumerator DestroyRock()
    {
        yield return new WaitForSeconds(delay - 1);
    }
}
