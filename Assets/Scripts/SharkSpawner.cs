using UnityEngine;

public class SharkSpawner : MonoBehaviour
{
    public GameObject sharkPrefab; // Assign the SharkPrefab here
    public float spawnInterval = 5f; // Time between spawns

    // Define minimum and maximum values for X and Y positions
    public float minSpawnX = 6f; // Minimum X position (right end)
    public float maxSpawnX = 16f; // Maximum X position (right end)
    public float minSpawnY = -5f; // Minimum Y position
    public float maxSpawnY = 5f;  // Maximum Y position

    private float timer;

    void Start()
    {
        timer = spawnInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            SpawnShark();
            timer = spawnInterval;
        }
    }

    void SpawnShark()
    {
        // Randomize X position between minSpawnX and maxSpawnX
        float spawnX = Random.Range(minSpawnX, maxSpawnX);
        // Randomize Y position between minSpawnY and maxSpawnY
        float spawnY = Random.Range(minSpawnY, maxSpawnY);

        Vector2 spawnPosition = new Vector2(spawnX, spawnY);

        Instantiate(sharkPrefab, spawnPosition, Quaternion.identity);
    }
}
