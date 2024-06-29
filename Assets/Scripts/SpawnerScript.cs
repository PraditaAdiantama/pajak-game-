using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    public float commonObjectProbability = 0.5f;
    public float rareObjectProbability = 0.1f;
    public float spawnInterval = 2f;
    public float spawnDelay = 0f;

    private float timeSinceLastSpawn;
    private Camera mainCamera;

    void Start()
    {
        timeSinceLastSpawn = spawnDelay;
        mainCamera = Camera.main;
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnObject();
            timeSinceLastSpawn = 0f;
        }
    }

    void SpawnObject()
    {
        float randomValue = Random.value;

        if (randomValue < commonObjectProbability)
        {
            int wordIndex = PlayerPrefs.GetInt("wordCount");
            Instantiate(objectPrefabs[wordIndex], GetRandomSpawnPosition(), Quaternion.identity);
        }
        else if (randomValue < commonObjectProbability + rareObjectProbability)
        {
            Instantiate(objectPrefabs[objectPrefabs.Length - 1], GetRandomSpawnPosition(), Quaternion.identity);
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        float randomY = Random.Range(-1f, 4f);

        return new Vector3(transform.position.x, randomY, transform.position.z);
    }
}
