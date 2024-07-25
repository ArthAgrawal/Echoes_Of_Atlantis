using UnityEngine;
using TMPro; // Ensure TextMeshPro is included

public class PlayerShooting : MonoBehaviour
{
    public GameObject crystalProjectilePrefab; // Assign the crystal projectile prefab here
    public Transform shootPoint; // Assign a point where the projectiles will be instantiated
    public float projectileSpeed = 10f; // Speed of the projectile
    public int maxCrystals = 25; // Maximum number of crystals
    public TextMeshProUGUI crystalText; // Assign the CrystalText UI element
    public AudioClip shootingSound; // Assign the shooting sound
    public AudioClip crystalCollectionClip; // Assign the crystal collection sound
    public float collectionSoundVolume = 0.5f; // Volume for collection sounds

    private int currentCrystals;
    private AudioSource audioSource;

    void Start()
    {
        currentCrystals = 0; // Initialize the crystal count
        audioSource = GetComponent<AudioSource>();
        UpdateCrystalText(); // Update the UI at the start
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && currentCrystals > 0) // Check if there are crystals left
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject crystal = Instantiate(crystalProjectilePrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody2D rb = crystal.GetComponent<Rigidbody2D>();
        rb.velocity = shootPoint.right * projectileSpeed; // Adjust direction as needed

        currentCrystals--; // Decrease the crystal count
        UpdateCrystalText(); // Update the UI

        // Play the shooting sound
        if (audioSource != null && shootingSound != null)
        {
            audioSource.PlayOneShot(shootingSound);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CrystalPickup"))
        {
            // Increase crystal count
            currentCrystals = Mathf.Clamp(currentCrystals + 1, 0, maxCrystals);
            UpdateCrystalText();

            // Play the crystal collection sound
            if (audioSource != null && crystalCollectionClip != null)
            {
                audioSource.PlayOneShot(crystalCollectionClip, collectionSoundVolume);
            }

            Destroy(other.gameObject); // Destroy the crystal pickup

        }
    }

    void UpdateCrystalText()
    {
        if (crystalText != null)
        {
            crystalText.text = "Crystals: " + currentCrystals.ToString();
        }
    }
}
