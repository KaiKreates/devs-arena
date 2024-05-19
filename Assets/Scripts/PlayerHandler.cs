using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Lava"))
        {
            Debug.Log("Game Over");
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            //Level Complete Screen
            Debug.Log("Level Complete");
        }

    }
}
