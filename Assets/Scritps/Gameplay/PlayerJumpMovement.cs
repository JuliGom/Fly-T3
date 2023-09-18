using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpMovement : MonoBehaviour
{
    [SerializeField] float jumpPower;
    [SerializeField] float fallMulti;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;

    Rigidbody2D rb;
    public bool isGrounded;
    Vector2 vecGravity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        vecGravity = new Vector2(0, -Physics2D.gravity.y);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(3.5f, 0.25f), CapsuleDirection2D.Horizontal, 0, groundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity -= vecGravity * fallMulti * Time.deltaTime;
        }
    }
}