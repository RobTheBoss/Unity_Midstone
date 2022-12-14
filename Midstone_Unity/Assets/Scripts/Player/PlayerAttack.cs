using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerAttack : MonoBehaviour
{
    private PlayerMovement pm;

    private AudioSource audioSource;

    private Vector2 attackDirection = new Vector2(1, 0);

    [SerializeField] GameObject projPrefab;
    public float projectileSpeed;
    public float projectileScale = 1.3f;

    [Header("Attack parameters")]
    public float attackInterval = 1.5f;
    private float attackTimer = 0;
    public Rigidbody2D projectilePrefab;

    [Header("Sounds")]
    public AudioClip attackSound;

    // Start is called before the first frame update
    void Start()
    {
        pm = GetComponent<PlayerMovement>();
        audioSource = GetComponent<AudioSource>();
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
        newProjectile.GetComponent<PlayerProjectile>().speed = projectileSpeed;
        newProjectile.transform.localScale = new Vector3(projectileScale, projectileScale, projectileScale);
        audioSource.PlayOneShot(attackSound);
    }

    public void LevelUp(BaseEnemy enemy)
    {
        audioSource.PlayOneShot(enemy.enemyDieSound);
        float scaleMultiplier = 1.07f;

        //scales projectile speed
        if (projectileSpeed <= 40.0f)
            projectileSpeed *= scaleMultiplier;
        else
            projectileSpeed = 40f;

        //scales projectile spawn cooldown
        scaleMultiplier = 1.05f;
        if (attackInterval > 0.1f)
            attackInterval /= scaleMultiplier;
        else
            attackInterval = 0.1f;

        //projectile size limit capped at 1.5f (not 2x since default size is less than 1.0f)
        scaleMultiplier = 1.05f;
        if (projectileScale <= 8f)
            projectileScale *= scaleMultiplier;
        else
            projectileScale = 8f;
    }
}
