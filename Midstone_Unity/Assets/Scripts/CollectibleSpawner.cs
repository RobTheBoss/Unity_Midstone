using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    public GameObject faceMe;

    private float spawnCooldown;
    private float spawnTimer;

    [Header("Boundaries")]
    public Vector2 minBounds;
    public Vector2 maxBounds;

    // Start is called before the first frame update
    void Start()
    {
        spawnCooldown = Random.Range(60, 180);
        spawnTimer = spawnCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer < 0)
        {
            SpawnPowerup();
        }
        else
        {
            spawnTimer -= Time.deltaTime;
        }
    }

    void SpawnPowerup()
    {
        float xPos = Random.Range(minBounds.x, maxBounds.x);
        float yPos = Random.Range(minBounds.y, maxBounds.y);

        Instantiate(faceMe, new Vector2(xPos, yPos), Quaternion.identity);

        Destroy(this);
    }
}
