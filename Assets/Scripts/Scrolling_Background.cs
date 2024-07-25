using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float scrollSpeed = 2f;
    public float backgroundWidth = 18.0f; // Width of one background sprite
    public float viewZone = 10f; // The distance at which to reposition the background

    private Transform[] backgroundParts;
    private Vector3 startPosition;

    void Start()
    {
        backgroundParts = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            backgroundParts[i] = transform.GetChild(i);
        }
        startPosition = transform.position;
    }

    void Update()
    {
        for (int i = 0; i < backgroundParts.Length; i++)
        {
            backgroundParts[i].Translate(Vector3.left * scrollSpeed * Time.deltaTime);

            if (backgroundParts[i].position.x < startPosition.x - viewZone)
            {
                RepositionBackgroundPart(backgroundParts[i]);
            }
        }
    }

    void RepositionBackgroundPart(Transform bgPart)
    {
        // Find the rightmost background part
        Transform rightmost = backgroundParts[0];
        Debug.Log(rightmost.position.x );
        for (int i = 1; i < backgroundParts.Length; i++)
        {
            if (backgroundParts[i].position.x > rightmost.position.x)
            {
                Debug.Log(backgroundParts[i].position.x );
                rightmost = backgroundParts[i];

            }
        }

        // Reposition the current background part to the right of the rightmost part
        bgPart.position = new Vector3(rightmost.position.x + backgroundWidth, bgPart.position.y, bgPart.position.z);
    }
}
