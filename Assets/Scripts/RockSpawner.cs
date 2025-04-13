using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject rockPrefab;
    public float spawnInterval = 3f;
    public Transform[] spawnPoints;

    void Start()
    {
        InvokeRepeating("SpawnRock", 1f, spawnInterval);
    }

    void SpawnRock()
    {
        int index = Random.Range(0, spawnPoints.Length);
        Instantiate(rockPrefab, spawnPoints[index].position, Quaternion.identity);
    }
}
