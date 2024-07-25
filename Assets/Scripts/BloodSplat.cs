using UnityEngine;

public class BloodSplat : MonoBehaviour
{
    public float lifespan = 1f; // Time in seconds before the blood splat disappears

    void Start()
    {
        // Destroy the blood splat after a certain lifespan
        Destroy(gameObject, lifespan);
    }
}
