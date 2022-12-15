using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    public GameObject faceMe;

    private AudioSource audioSource;

    private float spawnCooldown;
    private float spawnTimer;

    public AudioClip pickUpSound;

    [Header("Boundaries")]
    public Vector2 minBounds;
    public Vector2 maxBounds;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spawnCooldown = Random.Range(60, 180);
        spawnTimer = spawnCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer < 0)
        {
            SpawnPowerup();
            this.enabled = false;
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
        audioSource.PlayOneShot(pickUpSound);
    }
}
