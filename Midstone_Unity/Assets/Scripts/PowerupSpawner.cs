using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    public GameObject nICE;

    private float spawnCooldown = 40;
    private float spawnTimer;

    [Header("Boundaries")]
    public Vector2 minBounds;
    public Vector2 maxBounds;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = spawnCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer < 0)
        {
            SpawnPowerup();
            spawnTimer = spawnCooldown;
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

        Instantiate(nICE, new Vector2(xPos, yPos), Quaternion.identity);
    }
}
