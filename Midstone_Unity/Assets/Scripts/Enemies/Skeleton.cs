using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : BaseEnemy
{
    [SerializeField] private float retreatDistance;
    [SerializeField] private float chaseDistance;
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
