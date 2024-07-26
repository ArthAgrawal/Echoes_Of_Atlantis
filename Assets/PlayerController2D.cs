using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Speed of the player

    void Update()
    {
        // Get input from the ASWD keys
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate the new position
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);

        // Move the player
        transform.position += movement * speed * Time.deltaTime;
    }
}
