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

<<<<<<< Updated upstream
    public static int enemyKillCounter;
    public TextMeshProUGUI enemyKillCounterText;

    private Transform target;
    private Rigidbody2D rb;
=======
    protected Transform target;
    protected Rigidbody2D rb;
>>>>>>> Stashed changes

    // Start is called before the first frame update
    virtual protected void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    virtual protected void Update()
    {
        Attack();
    }

    virtual protected void Attack()
    {
        Vector2 dir = (target.position - transform.position).normalized;

        rb.velocity = dir * speed;
    }

    virtual protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //player takes damage
        }
    }
}
