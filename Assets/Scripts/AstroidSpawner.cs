using System.Collections;
using UnityEngine;

public class AstroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] asteroidPrefabs; // Array of asteroid prefabs
    [SerializeField] private Transform[] spawnPositions; // Array of spawn positions
    [SerializeField] private float initialSpawnInterval = 3f; // Initial spawn interval
    [SerializeField] private float midSpawnInterval = 2f; // Mid-level spawn interval
    [SerializeField] private float finalSpawnInterval = 1f; // Final spawn interval
    [SerializeField] private float transitionTime = 10f; // Time to transition between intervals

    private float currentSpawnInterval;

    void OnEnable()
    {
        currentSpawnInterval = initialSpawnInterval;
        StartCoroutine(AdjustSpawnInterval());
        StartCoroutine(SpawnAsteroids());
    }

    IEnumerator AdjustSpawnInterval()
    {
        // First transition to midSpawnInterval
        yield return new WaitForSeconds(transitionTime);
        currentSpawnInterval = midSpawnInterval;

        // Second transition to finalSpawnInterval
        yield return new WaitForSeconds(transitionTime);
        currentSpawnInterval = finalSpawnInterval;
    }

    IEnumerator SpawnAsteroids()
    {
        yield return new WaitForSeconds(1f); // Initial delay before spawning

        while (true) // Infinite loop for continuous spawning
        {
            // Pick a random asteroid prefab
            int randomAsteroidIndex = Random.Range(0, asteroidPrefabs.Length);
            GameObject asteroidToSpawn = asteroidPrefabs[randomAsteroidIndex];

            // Pick a random spawn position
            int randomPositionIndex = Random.Range(0, spawnPositions.Length);
            Transform spawnPosition = spawnPositions[randomPositionIndex];

            // Spawn the asteroid
            Instantiate(asteroidToSpawn, spawnPosition.position, Quaternion.identity);

            // Wait for the next spawn
            yield return new WaitForSeconds(currentSpawnInterval);
        }
    }
}
