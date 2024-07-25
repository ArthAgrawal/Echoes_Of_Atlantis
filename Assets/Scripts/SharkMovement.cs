using UnityEngine;

public class SharkMovement : MonoBehaviour
{
    public float speed = 2f; // Speed at which the shark moves

    void Update()
    {
        // Move the shark to the left
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Check if the shark has moved off-screen
        if (transform.position.x < -10f) // Adjust the threshold as needed
        {
            Destroy(gameObject); // Destroy the shark if it moves off-screen
        }
    }
}
