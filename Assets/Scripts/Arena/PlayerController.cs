using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public int allowedJumps = 0;
    public LayerMask groundLayer; // Layer to detect ground

    private Rigidbody2D rb;
    private Collider2D coll;
    private float moveInput;
    private Vector2 moveVelocity;
    private int jumpCount; // Number of jumps the player can still do
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        jumpCount = allowedJumps;
    }

    void Update()
    {
        // Handle horizontal movement
        moveInput = Input.GetAxisRaw("Horizontal");

        // Handle jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        // BUG: This resets the jumpCount right after the user presses space - thereby being able to jump an extra time
        // Check if the player is on the ground
        isGrounded = IsGrounded();
        if (isGrounded)
        {
            jumpCount = allowedJumps; // Reset jump count when the player is on the ground
        }
    }

    void FixedUpdate()
    {
        // Move the player by finding the target velocity
        Vector2 targetVelocity = new(moveInput * moveSpeed, rb.velocity.y);
        // And then smoothing it out and applying it to the player
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref moveVelocity, 0.05f);
    }

    void Jump()
    {
        if (isGrounded || jumpCount > 0)
        {
            Debug.Log("still Jumping");
            rb.AddForce(new Vector2(0,jumpForce), ForceMode2D.Impulse);
            jumpCount--;
        }
    }

    // Check if the player is on the ground by casting a small box under the player's feet
    bool IsGrounded()
    {
        float extraHeight = 0.1f;
        RaycastHit2D hit = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, extraHeight, groundLayer);
        return hit.collider != null;
    }
}
