using UnityEngine;

public class AnimalHealth : MonoBehaviour
{
    public int health = 1; // Set health value as needed

    public void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            Destroy(gameObject); // Destroy the animal if health is 0 or less
        }
    }
}
