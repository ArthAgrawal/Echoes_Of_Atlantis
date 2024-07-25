using UnityEngine;

public class PortalActivator : MonoBehaviour
{
    public GameObject portal;  // Assign your portal GameObject here
    public float activationTime = 30f;  // Time in seconds to activate the portal
    private float timer;

    private AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        if (portal != null)
        {
            portal.SetActive(false);  // Ensure the portal is hidden at the start
        }
        timer = 0f;

        // Get the AudioSource component attached to the portal
        if (portal != null)
        {
            audioSource = portal.GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= activationTime && portal != null)
        {
            portal.SetActive(true);  // Activate the portal after the specified time
            PlayActivationSound();  // Play sound when the portal activates
        }
    }

    void PlayActivationSound()
    {
        if (audioSource != null)
        {
            audioSource.Play();  // Play the portal activation sound
        }
    }
}
