using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    bool timerActive = false;

    public float freezeCooldown = 10;
    private float freezeTimer;

    private GameObject[] enemies;

    bool timeToDelete = false;

    void Start()
    {
        freezeTimer = freezeCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeToDelete)
            Destroy(gameObject);

        if (!timerActive)
            return;

        if (freezeTimer < 0)
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<BaseEnemy>().frozen = false;
            }

            timeToDelete = true;
        }
        else
        {
            freezeTimer -= Time.deltaTime;
        }

        Debug.Log(freezeTimer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            enemies = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<BaseEnemy>().frozen = true;
            }

            GameObject[] freezeThings = GameObject.FindGameObjectsWithTag("Freeze");
            foreach (GameObject freeze in freezeThings)
            {
                if (freeze != this.gameObject)
                    Destroy(freeze);
            }

            timerActive = true;
            Destroy(gameObject.GetComponent<SpriteRenderer>());
        }
    }
}
