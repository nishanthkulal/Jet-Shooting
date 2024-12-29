using UnityEngine;

public class BullateSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab; // The bullet prefab to spawn
    [SerializeField] private Transform spawnPoint; // The position where the bullet will spawn

    void Update()
    {
        // Check if the spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Spawn the bullet
            SpawnBullet();
            EventHandler.BullateSpawn();
        }
    }

    void SpawnBullet()
    {
        // Instantiate the bullet prefab at the spawn point's position and rotation
        Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
