using UnityEngine;

public class Jellyfish : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed at which the jellyfish moves from right to left
    public float lifespan = 10f; // Duration in seconds before the jellyfish disappears
    public AudioClip collisionSound; // Assign your audio clip here
    private AudioSource audioSource;

    void Start()
    {
        // Destroy the jellyfish after the specified lifespan
        Destroy(gameObject, lifespan);

        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing on the Jellyfish prefab.");
        }
    }

    void Update()
    {
        // Move the jellyfish from right to left
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
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

            // Reduce the player's oxygen
            PlayerOxygen playerOxygen = collision.GetComponent<PlayerOxygen>();
            if (playerOxygen != null)
            {
                playerOxygen.currentOxygen -= 30f; // Reduce oxygen by 30 units
                playerOxygen.currentOxygen = Mathf.Clamp(playerOxygen.currentOxygen, 0, playerOxygen.maxOxygen); // Ensure oxygen doesn't go below 0
            }

            // Destroy the jellyfish
            Destroy(gameObject, 0.7f);
        }
    }
}
