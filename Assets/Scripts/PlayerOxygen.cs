using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // For scene management

public class PlayerOxygen : MonoBehaviour
{
    public float maxOxygen = 100f;
    public float currentOxygen;
    public float oxygenDepletionRate = 4f;
    public float oxygenIncreaseAmount = 5f; // Amount of oxygen restored by boosters
    public TextMeshProUGUI oxygenText;
    public PlayerMovement playerMovement;
    public GameObject gameOverText; // Assign the Game Over Text here
    public GameObject gameOverPanel; // Assign the Game Over Panel here (optional)
    public AudioClip oxygenCollectionClip; // Assign the audio clip for collection
    public float collectionSoundVolume = 0.5f; // Volume for collection sounds
    private AudioSource audioSource; // Reference to the Audio Source component
    public GameObject bloodSplatPrefab; // Assign the blood splat prefab here
    private float baseSpeed;
    private bool isGameOver = false;

    void Start()
    {
        currentOxygen = maxOxygen;
        baseSpeed = playerMovement.speed;

        if (gameOverText != null)
        {
            gameOverText.SetActive(false); // Hide the Game Over text initially
        }

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false); // Hide the Game Over panel initially
        }

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isGameOver)
            return; // Skip update logic if the game is over

        // Decrease the oxygen level
        currentOxygen -= oxygenDepletionRate * Time.deltaTime;
        currentOxygen = Mathf.Clamp(currentOxygen, 0, maxOxygen);

        // Update the oxygen text
        oxygenText.text = "Oxygen: " + Mathf.Round(currentOxygen).ToString();

        // Adjust player speed based on oxygen level
        if (currentOxygen > 0)
        {
            playerMovement.speed = baseSpeed * (currentOxygen / maxOxygen);
        }
        else
        {
            // Trigger death condition
            EndGame();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("OxygenBooster"))
        {
            // Increase oxygen level
            currentOxygen += oxygenIncreaseAmount;
            currentOxygen = Mathf.Clamp(currentOxygen, 0, maxOxygen); // Ensure it doesn't exceed maxOxygen

            // Play the oxygen collection sound
            if (audioSource != null && oxygenCollectionClip != null)
            {
                audioSource.PlayOneShot(oxygenCollectionClip, collectionSoundVolume);
            }

            Destroy(other.gameObject); // Destroy the oxygen booster
        }
    }
    
    public void EndGame()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            playerMovement.speed = 0; // Stop the player

            if (gameOverText != null)
            {
                gameOverText.SetActive(true); // Show the Game Over text
            }

            if (gameOverPanel != null)
            {
                gameOverPanel.SetActive(true); // Show the Game Over panel
            }

            if (bloodSplatPrefab != null)
            {
                Instantiate(bloodSplatPrefab, transform.position, Quaternion.identity);
            }

            Debug.Log("Game Over: Player has died due to lack of oxygen.");
            Time.timeScale = 0; // Stop all game time
        }
    }

}
