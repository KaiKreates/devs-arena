using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    public float walkSpeed = 5f;
    public float runSpeed = 10f; // Speed when 'E' is pressed
    public float jumpPower = 5f;
    public float highJumpPower = 10f; // Higher jump power when 'Q' is pressed
    public float maxVelocityChange = 10f;

    private bool isGrounded = false;
    private bool isRunning = false;
    private bool highJump = false; // Flag for higher jump

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        // Higher jump when 'Q' is pressed
        if (Input.GetKeyDown(KeyCode.Q))
        {
            highJump = true;
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            highJump = false;
        }

        // Running when 'E' is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            isRunning = true;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            isRunning = false;
        }

        // Jump logic
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        targetVelocity = transform.TransformDirection(targetVelocity);
        targetVelocity *= isRunning ? runSpeed : walkSpeed;

        Vector3 velocity = rb.velocity;
        Vector3 velocityChange = (targetVelocity - velocity);
        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
        velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
        velocityChange.y = 0;

        rb.AddForce(velocityChange, ForceMode.VelocityChange);
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        rb.AddForce(Vector3.up * (highJump ? highJumpPower : jumpPower), ForceMode.VelocityChange);
    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
