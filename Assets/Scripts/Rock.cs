using UnityEngine;

public class Rock : MonoBehaviour
{
    public float amplitude = 1f;  // Height of the floating effect
    public float frequency = 2f;    // Speed of the floating effect


    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float yOffset = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = startPos + new Vector3(0, yOffset, 0);
       
    }
   

    
}
