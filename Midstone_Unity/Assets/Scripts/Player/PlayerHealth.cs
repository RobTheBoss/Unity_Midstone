using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour 
{
	public int maxHealth;
	public float health;
	public GameObject gameOverCanvas;

	// Starts before the first frame

	void Start()
	{
		health = maxHealth;

		Time.timeScale = 1;
	}

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Time.timeScale = 0;
            gameOverCanvas.SetActive(true);
            //BaseEnemy.enemyKillCounter = 0;
        }
        else
            Time.timeScale = 1;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Hp = " + health.ToString());
    }
}
