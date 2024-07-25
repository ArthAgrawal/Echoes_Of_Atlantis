using UnityEngine;

public class CrystalMovement : MonoBehaviour
{
    public float speed = 2f; // Speed at which the crystal moves

    void Update()
    {
        // Move the crystal from right to left
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Destroy the crystal if it goes off-screen (optional)
        if (transform.position.x < -10f) // Adjust this value as needed
        {
            Destroy(gameObject);
        }
    }
}
