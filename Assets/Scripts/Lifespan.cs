using UnityEngine;

public class Lifespan : MonoBehaviour
{
    public float lifespan = 5f; // Time in seconds before the object is destroyed

    void Start()
    {
        Destroy(gameObject, lifespan); // Destroy the object after the specified lifespan
    }
}
