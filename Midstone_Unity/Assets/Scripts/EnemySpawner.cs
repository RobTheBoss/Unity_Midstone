using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnDistance;

    public GameObject[] enemyPrefabs;

    [SerializeField] float originalSpawnCooldown;
    float spawnTimer;

    private Transform playerPos;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = originalSpawnCooldown;
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
        }
        else
        {
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            GameObject enemyToSpawn = enemyPrefabs[enemyIndex];

            float x = Random.Range(-1.0f, 1.0f);
            float y = Random.Range(-1.0f, 1.0f);
            Vector2 spawnDirection = new Vector2(x, y).normalized;

            Vector2 spawnPosition = (Vector2)playerPos.position + (spawnDirection * spawnDistance);
            spawnPosition = spawnPosition.normalized * spawnDistance;

            Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);

            spawnTimer = originalSpawnCooldown;
        }
    }
}