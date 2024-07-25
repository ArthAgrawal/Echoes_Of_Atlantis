using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class Portal2 : MonoBehaviour
{
    public string sceneToLoad; // Name of the scene to load
    private AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        // Get the AudioSource component attached to the portal
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayPortalSound();  // Play sound when player enters portal
            LoadScene();
        }
    }

    void PlayPortalSound()
    {
        if (audioSource != null)
        {
            audioSource.Play();  // Play the portal entry sound
        }
    }

    void LoadScene()
    {
        // Check if the scene name is valid and exists
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            // Load the specified scene
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogError("Scene name is empty or not set.");
        }
    }
}
