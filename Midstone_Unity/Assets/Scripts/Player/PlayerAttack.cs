using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerAttack : MonoBehaviour
{
    private PlayerMovement pm;

    private Vector2 attackDirection = new Vector2(1, 0);
    private float attackTimer = 0;

    [SerializeField] GameObject projPrefab;
    public float projectileSpeed;

    [Header("Attack parameters")]
    public float attackInterval = 1.5f;
    public Rigidbody2D projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        pm = GetComponent<PlayerMovement>();
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
        if (pm.attackDirection != Vector2.zero)
            attackDirection = pm.attackDirection;
    }

    private void Attack()
    {
        Vector3 spawnPoint = new Vector3(transform.position.x, transform.position.y + 1.5f, 1);
        GameObject newProjectile = Instantiate(projPrefab, spawnPoint, Quaternion.identity);
        newProjectile.GetComponent<PlayerProjectile>().direction = attackDirection;
    }
}
