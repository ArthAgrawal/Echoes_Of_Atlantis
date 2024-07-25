using UnityEngine;

public class SharkCollisionHandler : MonoBehaviour
{
    public GameObject player; // Reference to the player GameObject
    private AudioSource playerAudioSource; // Reference to the AudioSource component on the player
    private PlayerOxygen playerOxygen; // Reference to the PlayerOxygen script

    void Start()
    {
        // Find the player GameObject and get its AudioSource component
        player = GameObject.Find("Character"); // Ensure this name matches your player GameObject
        if (player != null)
        {
            playerAudioSource = player.GetComponent<AudioSource>(); // Get the AudioSource component from the player
            playerOxygen = player.GetComponent<PlayerOxygen>(); // Get the PlayerOxygen component from the player
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player hit the shark!");

            // Play the blood splatter sound effect
            PlayBloodSound();

            // Call the EndGame method in the PlayerOxygen script
            if (playerOxygen != null)
            {
                playerOxygen.EndGame();
            }

            // Destroy the player GameObject
            DestroyPlayer();
        }
    }

    void PlayBloodSound()
    {
        if (playerAudioSource != null)
        {
            playerAudioSource.Play(); // Play the audio clip assigned to the AudioSource
        }
    }

    void DestroyPlayer()
    {
        if (player != null)
        {
            Destroy(player, 0.7f); // Destroy the player GameObject
        }
    }
}
