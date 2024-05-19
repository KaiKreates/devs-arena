using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FracturedRock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Random.rotation;
        GetComponent<Rigidbody>().AddForce(transform.up * 200);
        Invoke("DestroyPiece", 1);
    }

    void DestroyPiece()
    {
        Destroy(transform.parent.gameObject);
    }
}
