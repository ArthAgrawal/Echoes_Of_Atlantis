using UnityEngine;

public class SetSpriteColor : MonoBehaviour
{
    public Color targetColor = Color.blue; // The color you want to assign

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Get the SpriteRenderer component
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Check if the component is found
        if (spriteRenderer != null)
        {
            // Assign the target color to the sprite renderer
            spriteRenderer.color = targetColor;
        }
        else
        {
            Debug.LogError("SpriteRenderer component is missing!");
        }
    }
}
