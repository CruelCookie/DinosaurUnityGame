using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] objects;

    private bool spawning = true;

    void Start()
    {
        StartSpawning();
    }

    public void StartSpawning()
    {
       spawning = true;
       StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (spawning)
        {
            Spawn();
            float spawnDelay = Random.Range(Global.minSpawnDelay, Global.maxSpawnDelay);
            Global.maxSpawnDelay = Mathf.Max(Global.minSpawnDelay, Global.maxSpawnDelay - Global.SpeedIncrease);
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private void Spawn()
    {
        int randomObjIndex = Random.Range(0, objects.Length);
        GameObject obstacle = Instantiate(objects[randomObjIndex]);
        obstacle.transform.position = transform.position;
    }

    public void CancelSpawn()
    {
        spawning = false;
        StopAllCoroutines();
    }
}