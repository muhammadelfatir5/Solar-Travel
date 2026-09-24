using UnityEngine;

public class scriptSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float spawnInterval = 1f;
    public float spawnRangeY = 4.5f;

    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObject();
            timer = 0f;
        }
    }

    void SpawnObject()
    {
        float randomY = Random.Range(-spawnRangeY, spawnRangeY);
        Vector3 spawnPos = new Vector3(transform.position.x, randomY, 0);
        Instantiate(asteroidPrefab, spawnPos, Quaternion.identity);
    }
}
