using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkController : MonoBehaviour
{
    private Vector3 targetPos;
    public Transform player;
    public float runSpeed;
    public void Start()
    {
        Debug.Log("Chase State");
        targetPos = player.position;
    }

    public void Update()
    {
        //Rotate towards target position
        Vector3 lookDir = Vector3.RotateTowards(transform.forward, targetPos - transform.position, 1 * Time.deltaTime, 0);
        transform.rotation = Quaternion.LookRotation(lookDir);

        //Move Forward
        transform.position += transform.forward * runSpeed * Time.deltaTime;

    }
}
