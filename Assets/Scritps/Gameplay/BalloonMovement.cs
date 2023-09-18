using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BalloonMovement : MonoBehaviour
{

    Rigidbody2D rb;
    public float jumpForce;
    public bool balloonOn;
    public float balloonDelay;
    public bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;




    // Start is called before the first frame update
    void Start()
    {
        balloonOn = false;
        rb = GetComponent<Rigidbody2D>();
        balloonDelay = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(2f, 0.6f), CapsuleDirection2D.Horizontal, 0, groundLayer);

        if (Input.GetButtonDown("Jump"))
        {
            balloonOn = true;
        }
        if (Input.GetButtonUp("Jump"))
        {
            balloonOn = false;
        }
    }

    private void FixedUpdate()
    {
        switch (balloonOn)
        {
            case true:
                if (balloonDelay > 0)
                {
                    balloonDelay -= Time.deltaTime;
                    rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Force);
                }
            break;

            case false:
                if (balloonDelay > 1f)
                {
                    balloonDelay = 1f;
                }
                else
                {
                    if (isGrounded == true)
                    {
                        balloonDelay += Time.deltaTime;
                    }
                }
                if (balloonDelay < 0)
                {
                    rb.AddForce(new Vector2(0f, 0f), ForceMode2D.Force);
                }
            break;
        }
    }
}
