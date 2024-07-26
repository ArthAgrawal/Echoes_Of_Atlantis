using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float speed = 2f; // Speed of the enemy

    void Update()
    {
        if (player != null)
        {
            // Calculate direction from enemy to player
            Vector3 direction = player.position - transform.position;
            direction.Normalize();

            // Move the enemy towards the player
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
