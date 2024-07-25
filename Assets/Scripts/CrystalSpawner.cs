using UnityEngine;

public class CrystalSpawner : MonoBehaviour
{
    public GameObject crystalPickupPrefab; // Assign the crystal pickup prefab here
    public float spawnInterval = 10f; // Time between spawns
    public float spawnRangeX = 10f; // Range for random X position
    public float spawnRangeY = 5f;  // Range for random Y position
    public float crystalLifespan = 5f; // Lifespan of each crystal in seconds

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
            SpawnCrystal();
            timer = spawnInterval;
        }
    }

    void SpawnCrystal()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        float randomY = Random.Range(-spawnRangeY, spawnRangeY);
        Vector2 spawnPosition = new Vector2(randomX, randomY);

        GameObject crystal = Instantiate(crystalPickupPrefab, spawnPosition, Quaternion.identity);

        // Ensure that the crystal prefab has the Lifespan script
        Lifespan lifespanComponent = crystal.GetComponent<Lifespan>();
        if (lifespanComponent != null)
        {
            lifespanComponent.lifespan = crystalLifespan; // Set the lifespan for the spawned crystal
        }
    }
}
