using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifetime = 2f; // Time before the projectile is destroyed
    public float projectileSpeed = 10f; // Speed of the projectile

    void Start()
    {
        // Destroy the projectile after its lifetime
        Destroy(gameObject, lifetime);
    }

    void FixedUpdate()
    {
        // Move the projectile forward
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = transform.right * projectileSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Handle collision with animal
            Destroy(other.gameObject); // Destroy the animal
            Destroy(gameObject); // Destroy the projectile
        }
    }
}
