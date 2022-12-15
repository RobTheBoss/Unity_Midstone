using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnDistance;

    public GameObject[] enemyPrefabs;

    [SerializeField] float originalSpawnCooldown;
    float spawnCooldown;
    float spawnTimer;

    private Transform playerPos;

    float hpMultiplier = 1f;
    public Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = originalSpawnCooldown;
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Sets scaling multipliers based on time
        if (hpMultiplier > 6)
            hpMultiplier = 6;
        else
        {
            float healthScalingReducer = 150f;
            hpMultiplier = 1 + (timer.currentTime / healthScalingReducer);
        }

        float timeScale = 300.0f;
        float spawnSpeedPercent = timer.currentTime / timeScale;

        if (spawnSpeedPercent >= 1.0f)
            spawnSpeedPercent = 1.0f;

        spawnCooldown = originalSpawnCooldown - (originalSpawnCooldown * spawnSpeedPercent);
        if (spawnCooldown <= 0.1f)
            spawnCooldown = 0.1f;

        Debug.Log(spawnCooldown);

        //Spawns random enemy
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

            GameObject enemyInstance = Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);

            //scaling
            enemyInstance.GetComponent<BaseEnemy>().health *= hpMultiplier;

            spawnTimer = spawnCooldown;
        }
    }
}