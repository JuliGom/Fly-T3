using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float speedMove;
    Vector2 move;
    Rigidbody2D rb;
    Animator anim;
    public int health;
    public Vector3 respawn;
    public bool has2Balloon;
    public bool has3Balloon;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        health = 3;
        respawn = transform.position;
    }

    private void Update()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, -6.5f, 6.5f);
        transform.position = pos;

        if (GetComponent<BalloonMovement>().isGrounded == false)
        {
            move = new Vector2(Input.GetAxis("Horizontal"), 0);

            rb.AddForce(move * speedMove);
            
            if (Input.GetAxis("Horizontal") < 0)
            {
                anim.SetBool("GoRight", true);
            }
            else
            {
                if(Input.GetAxis("Horizontal") > 0)
                {
                    anim.SetBool("GoLeft", true);
                }
            }
        }
        else
        {
            anim.SetBool("GoLeft", false);
            anim.SetBool("GoRight", false);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Prick")
        {
            health -= 1;

            if (health == 2)
            {
                GameObject.Find("Heart3").SetActive(false);
                transform.position = respawn;
            }
            else
            {
                if (health == 1)
                {
                    GameObject.Find("Heart2").SetActive(false);
                    transform.position = respawn;
                }
                else
                {
                    if (health == 0)
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    }
                }
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Checkpoint")
        {
            respawn = collision.transform.position;
            collision.GetComponent<Animator>().SetBool("isPointed", true);
        }

        if (collision.gameObject.tag == "Yellow")
        {
            has2Balloon = true;
            has3Balloon = false;
            anim.SetBool("2Balloons", true);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Green")
        {
            if (has2Balloon == true)
            {
                anim.SetBool("3Balloons", true);
                has2Balloon = false;
                has3Balloon = true;
                Destroy(collision.gameObject);
            }
            else
            {
                anim.SetBool("2Balloons", true);
                has2Balloon = true;
                has3Balloon = false;
                Destroy(collision.gameObject);
            }
        }
    }
}
                                            