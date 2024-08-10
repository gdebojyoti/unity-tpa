using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 4f; // Speed at which the enemy moves
    public float raycastDistance = 0.1f; // Distance for raycast checks
    public bool movingRight = true; // Initial movement direction

    private Rigidbody2D rb;
    // private Collider2D coll;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // coll = GetComponent<Collider2D>();
    }

    void Update()
    {
        // Check for collisions on the left and right
        CheckCollisions();
    }

    void FixedUpdate()
    {
        // Move the enemy
        Move();
    }

    void Move()
    {
        // Determine the movement direction
        float direction = movingRight ? 1f : -1f;

        // Move the enemy by finding the target velocity
        Vector2 targetVelocity = new(direction * moveSpeed, rb.velocity.y);
        // And then smoothing it out and applying it to the enemy
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref targetVelocity, 0.05f);
    }

    void CheckCollisions()
    {
        // Cast rays on the left and right sides of the enemy
        Vector2 position = transform.position;
        Vector2 direction = movingRight ? Vector2.right : Vector2.left;

        // Adjust raycast origins and directions based on collider size
        RaycastHit2D hit = Physics2D.Raycast(position, direction, raycastDistance);
        // if (hit.collider != null && hit.collider.CompareTag("Ground"))
        if (hit.collider != null)
        {
            // Reverse direction upon collision with a ground tile
            movingRight = !movingRight;
        }
    }
}
