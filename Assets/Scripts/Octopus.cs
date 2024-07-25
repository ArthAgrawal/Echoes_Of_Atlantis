using UnityEngine;

public class Octopus : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed at which the octopus moves
    public float verticalMoveSpeed = 2f; // Speed at which the octopus moves vertically
    public float lifespan = 10f; // Duration in seconds before the octopus disappears
    public AudioClip collisionSound; // Assign your audio clip here

    private AudioSource audioSource;
    private bool isMovingVertically = false; // Flag to check if the octopus should move vertically
    private float verticalDirection = 1f; // Direction of vertical movement

    private PlayerOxygen playerOxygen; // Reference to PlayerOxygen script

    void Start()
    {
        // Log message to confirm Start method is called
        Debug.Log("Octopus Start method called.");

        // Destroy the octopus after the specified lifespan
        Destroy(gameObject, lifespan);

        // Get the AudioSource component and log if it's null
        audioSource = GetComponent<AudioSource>();

        // Get a reference to the PlayerOxygen script
        playerOxygen = FindObjectOfType<PlayerOxygen>();
    }

    void Update()
    {
        if (isMovingVertically)
        {
            // Move vertically
            transform.Translate(Vector2.up * verticalMoveSpeed * verticalDirection * Time.deltaTime);
            // Change direction if reaching the screen limits (you might need to adjust these values)
            if (transform.position.y > 5f || transform.position.y < -5f)
            {
                verticalDirection *= -1; // Reverse vertical direction
            }
        }
        else
        {
            // Move horizontally
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Play the collision sound
            if (audioSource != null && collisionSound != null)
            {
                audioSource.PlayOneShot(collisionSound);
            }
            else
            {
                Debug.LogError("AudioSource or collisionSound is null.");
            }

            // Call the EndGame method from PlayerOxygen script
            if (playerOxygen != null)
            {
                playerOxygen.EndGame();
            }

            // Destroy the player
            Destroy(collision.gameObject, 0.7f);
        }
        else if (collision.CompareTag("Crystal"))
        {
            Debug.Log("Collision Detected");
            // Change direction to vertical movement when hit by a crystal
            isMovingVertically = true;
        }
    }
}
