using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkController : MonoBehaviour
{
    private Vector3 playerPos;
    public Transform player;
    public GameObject fractureRockPrefab;
    public GameOver gameOverManager;

    public float slowDuration;
    public float swimSpeed;

    public void Start()
    {
        if (gameOverManager == null)
        {
            gameOverManager = FindObjectOfType<GameOver>();
        }

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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            //Break Rock
            Destroy(collision.gameObject);
            Instantiate(fractureRockPrefab, collision.transform.position, Quaternion.identity);
            //slow shark
            swimSpeed = 2;
            StartCoroutine(SlowShark());
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            //gameover
            Debug.Log("Game Over");
            gameOverManager.ShowGameOverScreen();


        }
    }

    IEnumerator SlowShark()
    {
        yield return new WaitForSeconds(slowDuration);

        swimSpeed = 5;
    }
}
