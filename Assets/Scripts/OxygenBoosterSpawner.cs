using UnityEngine;

public class OxygenBoosterSpawner : MonoBehaviour
{
    public GameObject oxygenBoosterPrefab; // Assign the OxygenBooster prefab here
    public float spawnInterval = 10f; // Time between spawns
    public float spawnRangeY = 5f;  // Range for random Y position

    public float spawnX = 10f; // X position where boosters will spawn (right edge)

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
            SpawnOxygenBooster();
            timer = spawnInterval;
        }
    }

    void SpawnOxygenBooster()
    {
        float randomY = Random.Range(-spawnRangeY, spawnRangeY);
        Vector2 spawnPosition = new Vector2(spawnX, randomY);

        Instantiate(oxygenBoosterPrefab, spawnPosition, Quaternion.identity);
    }
}
