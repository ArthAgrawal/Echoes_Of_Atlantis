using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private int itemCount = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            itemCount++;
            Debug.Log("Items Collected: " + itemCount);
            Destroy(other.gameObject);
        }
    }
}

