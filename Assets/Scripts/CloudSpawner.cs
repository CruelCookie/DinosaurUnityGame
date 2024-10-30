using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] GameObject cloudPrefab; 
    private float minSpawnDelay = 1f;
    private float maxSpawnDelay = 3f;

    private bool spawning = true;

    void Start()
    {
        StartSpawningClouds();
    }

    public void StartSpawningClouds()
    {
        spawning = true;
        StartCoroutine(CloudSpawnRoutine());
    }

    private IEnumerator CloudSpawnRoutine()
    {
        while (spawning)
        {
            SpawnCloud();
            float spawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private void SpawnCloud()
    {
        float offsetY = Random.Range(-1f, 2.5f);
        
        GameObject cloud = Instantiate(cloudPrefab);
        cloud.transform.position = new Vector3(
        transform.position.x,
        transform.position.y + offsetY,
        transform.position.z
    );
    }

    public void StopCloudSpawning()
    {
        spawning = false;
        StopAllCoroutines();
    }
}