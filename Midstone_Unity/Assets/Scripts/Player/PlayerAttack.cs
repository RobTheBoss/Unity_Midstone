using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerAttack : MonoBehaviour
{
    private Rigidbody2D rb;

    private Vector2 attackDirection = new Vector2(1, 0);
    private float attackTimer = 0;
    private float projectileAttackForce = 1500.0f;

    [Header("Attack parameters")]
    public float attackInterval = 1.5f;
    public Rigidbody2D projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer > attackInterval)
        {
            attackTimer = 0;
            Attack();
        }
    }
    private void FixedUpdate()
    {
        //Sets the attack direction to the velocity direction
        if (rb.velocity != Vector2.zero)
            attackDirection = rb.velocity.normalized;
    }

    private void Attack()
    {
        Rigidbody2D newProjectile = Instantiate(projectilePrefab, rb.transform);
        newProjectile.AddForce(attackDirection * projectileAttackForce);
    }
}
