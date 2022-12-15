using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour 
{
    private AudioSource audioSource;
    
    public int maxHealth;
	public float health;
	public GameObject gameOverCanvas;

    [Header("Sounds")]
    public AudioClip playerDieSound;

    // Starts before the first frame

    void Start()
	{
        audioSource = GetComponent<AudioSource>();
        
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
            audioSource.PlayOneShot(playerDieSound);
            this.enabled = false;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Hp = " + health.ToString());
    }
}
