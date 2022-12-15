using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    public Vector2 attackDirection;

    [Header("Movement variables")]
    [SerializeField] float speed;

    [Header("Boundaries")]
    public Vector2 minPlayerBounds;
    public Vector2 maxPlayerBounds;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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

        //Animates player facing direction depending on direction moving
        if (moveDirection.x == 1)
            anim.SetTrigger("FaceRight");
        else if (moveDirection.x == -1)
            anim.SetTrigger("FaceLeft");
        else if (moveDirection.y == 1)
            anim.SetTrigger("FaceBack");
        else if (moveDirection.y == -1)
            anim.SetTrigger("FaceFront");

        rb.velocity = moveDirection * speed;

        if (rb.velocity != Vector2.zero)
            attackDirection = rb.velocity.normalized;
    }
}
