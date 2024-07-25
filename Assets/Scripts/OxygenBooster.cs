using UnityEngine;

public class OxygenBooster : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed at which the booster moves from right to left
    public float lifespan = 3f;  // Duration in seconds before the booster disappears

    void Start()
    {
        // Destroy the booster after the specified lifespan
        Destroy(gameObject, lifespan);
    }

    void Update()
    {
        // Move the booster from right to left
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }
}
