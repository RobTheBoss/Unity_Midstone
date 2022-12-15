using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : BaseEnemy
{
    [SerializeField] GameObject boneProjectile;
    [SerializeField] private float retreatDistance;
    [SerializeField] private float chaseDistance;

    [SerializeField] private float projCooldown;

    private float projTimer;

    override protected void Start()
    {
        base.Start();
        projTimer = projCooldown;
    }

    protected override void Update()
    {
        if (!frozen)
        {
            base.Update();

            if (projTimer > 0)
                projTimer -= Time.deltaTime;
            else
            {
                GameObject temp = Instantiate(boneProjectile, transform.position, Quaternion.identity);
                if (temp.TryGetComponent(out SkelProjectile proj))
                {
                    proj.direction = (target.position - transform.position).normalized;
                }

                projTimer = projCooldown;
            }
        }

        if (frozen)
            rb.velocity = Vector2.zero;
    }
    protected override void Attack()
    {
        Vector2 dir = (target.position - transform.position).normalized;
        float distance = (target.position - transform.position).magnitude;

        //moves towards player
        if (distance > chaseDistance)
            rb.velocity = dir * speed;

        //moves away from player
        else if (distance < retreatDistance)
            rb.velocity = -dir * speed;

        else
            rb.velocity = Vector2.zero;
    }
}
