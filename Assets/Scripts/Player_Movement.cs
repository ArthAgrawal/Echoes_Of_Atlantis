using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Animator animator;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float highGravityScale = 10f; // Gravity scale to apply when close to the shark
    private bool isImmobilized = false; // Indicates whether the player should be immobilized

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isImmobilized)
            return; // Skip movement if immobilized

        // Get input from WASD keys
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Trigger the swimming animation when moving
        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetBool("IsSwimming", true);
        }
        else
        {
            animator.SetBool("IsSwimming", false);
        }
    }

    void FixedUpdate()
    {
        if (isImmobilized)
            return; // Skip movement if immobilized

        // Move the player
        Vector2 newPosition = rb.position + movement * speed * Time.fixedDeltaTime;

        // Clamp the new position to stay within camera bounds
        newPosition.x = Mathf.Clamp(newPosition.x, -6f, 6f);
        newPosition.y = Mathf.Clamp(newPosition.y, -3f, 4f);

        rb.MovePosition(newPosition);
    }

    public void ApplyHighGravity()
    {
        rb.gravityScale = highGravityScale; // Increase gravity to make the player fall
        isImmobilized = true; // Stop player movement
    }

    public void ResetGravity()
    {
        rb.gravityScale = 1f; // Reset gravity scale to default
        isImmobilized = false; // Allow movement again
    }
}
