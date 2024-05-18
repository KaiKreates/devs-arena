using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkController : MonoBehaviour
{
    private Vector3 playerPos;
    public Transform player;

    private float cooldown = 0;
    public float cooldownDuration;
    public float swimSpeed;
    public float slowSpeed;

    public LayerMask whatIsRock;
    public LayerMask whatIsPlayer;

    public void Start()
    {

    }

    public void Update()
    {
        playerPos = player.position;
        //Rotate towards target position
        Vector3 targetPos = new Vector3(playerPos.x - transform.position.x, 0, playerPos.z - transform.position.z);
        Vector3 lookDir = Vector3.RotateTowards(transform.forward, targetPos, 1 * Time.deltaTime, 0);
        transform.rotation = Quaternion.LookRotation(lookDir);

        //Move Forward
        transform.position += transform.forward * swimSpeed * Time.deltaTime;

        float delta = 5;
        for (int i = -3; i <= 3; i++)
        {
            //Wall Detection
            var dir = Quaternion.Euler(0, i * delta, 0) * transform.forward;
            Debug.DrawRay(transform.position, dir * 8, Color.green);

            if (Physics.Raycast(transform.position, dir, 8, whatIsRock))
            {
                swimSpeed = slowSpeed;
                cooldown = Time.time + cooldownDuration;
            }
        }

        if(cooldown < Time.time)
            //revert back to swimSpeed;

        //Detect Player
        if (Physics.Raycast(transform.position, transform.forward, 3, whatIsPlayer))
        {
            //Gameover
        }
    }
}
