using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private Vector2 attackDirection;

    [Header("Movement variables")]
    [SerializeField] float accelForce;
    [SerializeField] float frictionForce;
    [SerializeField] float maxSpeed;

    [Header("Boundaries")]
    public Vector2 minPlayerBounds;
    public Vector2 maxPlayerBounds;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Gets player movement input
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");

        if (transform.position.x < minPlayerBounds.x)
            transform.position = new Vector3 (minPlayerBounds.x, transform.position.y, 0);
        else if (transform.position.x > maxPlayerBounds.x)
            transform.position = new Vector3(maxPlayerBounds.x, transform.position.y, 0);

        if (transform.position.y < minPlayerBounds.y)
            transform.position = new Vector3(transform.position.x, minPlayerBounds.y, 0);
        else if (transform.position.y > maxPlayerBounds.y)
            transform.position = new Vector3(transform.position.x, maxPlayerBounds.y, 0);
    }

    private void FixedUpdate()
    {
        //Adds force in direction player is moving
        rb.AddForce(moveDirection * accelForce);

        if (moveDirection.x == 0 && rb.velocity.x != 0 || Mathf.Sign(moveDirection.x) != Mathf.Sign(rb.velocity.x)) //if no input or opposing current x movement
        {
            float frictionForceX = Mathf.Sign(rb.velocity.x) * -frictionForce * Time.fixedDeltaTime;

            //makes sure friction force gets the player velocity on exactly 0 and not past it
            if (Mathf.Abs(frictionForceX) >= Mathf.Abs(rb.velocity.x))
                frictionForceX = -rb.velocity.x;

            rb.AddForce(new Vector2(frictionForceX, 0), ForceMode2D.Impulse);
        }

        if (moveDirection.y == 0 && rb.velocity.y != 0 || Mathf.Sign(moveDirection.y) != Mathf.Sign(rb.velocity.y)) //if no input or opposing current y movement
        {
            float frictionForceY = Mathf.Sign(rb.velocity.y) * -frictionForce * Time.fixedDeltaTime;

            //makes sure friction force gets the player velocity on exactly 0 and not past it
            if (Mathf.Abs(frictionForceY) >= Mathf.Abs(rb.velocity.y))
                frictionForceY = -rb.velocity.y;

            rb.AddForce(new Vector2(0, frictionForceY), ForceMode2D.Impulse);
        }

        //Sets a speed cap
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        //Sets the attack direction to the velocity direction
        if (rb.velocity != Vector2.zero)
            attackDirection = rb.velocity.normalized;
    }
}
