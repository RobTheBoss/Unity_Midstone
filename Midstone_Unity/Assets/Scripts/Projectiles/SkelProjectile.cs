using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class SkelProjectile : MonoBehaviour
{
    Rigidbody2D rb;
    [HideInInspector] public Vector2 direction;
    public float speed;
    [SerializeField] private int damage;

    [SerializeField] float destroyCooldown;
    float destroyTimer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction * speed;

        destroyTimer = destroyCooldown;
    }

    private void Update()
    {
        destroyTimer -= Time.deltaTime;

        if (destroyTimer <= 0)
            Destroy(this.gameObject);

        transform.Rotate(new Vector3(0, 0, -300 * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
