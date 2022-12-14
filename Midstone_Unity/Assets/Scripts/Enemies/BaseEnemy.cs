using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class BaseEnemy : MonoBehaviour
{
    public float health;
    public float damage;
    public float speed;

    public TextMeshProUGUI enemyKillCounterText;
    public PlayerStats playerStats;

    protected Transform target;
    protected Rigidbody2D rb;

    public bool frozen = false;

    [Header("Sounds")]
    public AudioClip enemyDieSound;

    // Start is called before the first frame update
    virtual protected void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();

        playerStats = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    virtual protected void Update()
    {
        Attack();
    }

    virtual protected void Attack()
    {

        if (!frozen)
        {
            Vector2 dir = (target.position - transform.position).normalized;

            rb.velocity = dir * speed;
        }

        if (frozen)
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void TakeDamage(int damage_)
    {
        health -= damage_;

        if (health <= 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>().LevelUp(this);
            playerStats.AddKill();
            Destroy(this.gameObject);
        }
    }

    virtual protected void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 dir = (target.position - transform.position).normalized;

            rb.velocity = -dir * speed;

            //player takes damage
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage * Time.deltaTime);
        }
    }
}
