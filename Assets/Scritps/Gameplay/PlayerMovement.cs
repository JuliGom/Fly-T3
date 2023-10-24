using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Animations;
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

    IEnumerator BonusGameplayLoad()
    {
        yield return new WaitForSeconds(1f);
        if (SceneManager.GetActiveScene().name == "Gameplay")
        {
            SceneManager.LoadScene("Bonus");
        }
        else
        {
            if (SceneManager.GetActiveScene().name == "Gameplay2")
            {
                SceneManager.LoadScene("Bonus2");
            }
            else
            {
                if (SceneManager.GetActiveScene().name == "Gameplay3")
                {
                    SceneManager.LoadScene("Bonus3");
                }
                else
                {
                    if (SceneManager.GetActiveScene().name == "Gameplay4")
                    {
                        SceneManager.LoadScene("Bonus4");
                    }
                    else
                    {
                        SceneManager.LoadScene("Bonus5");
                    }
                }
            }
        }
    }


    IEnumerator DeadAnimation()
    {
        anim.SetBool("IsDead", true);

        if (has2Balloon == true)
        {
            GameObject.Find("Balloon").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("Balloon").GetComponent<Animator>().SetBool("Yellowpop", true);
        }
        else
        {
            if (has3Balloon == true)
            {
                GameObject.Find("Balloon").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("Balloon").GetComponent<Animator>().SetBool("Greenpop", true);
            }
            else
            {
                GameObject.Find("Balloon").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("Balloon").GetComponent<Animator>().SetBool("Redpop", true);
            }
        }

        GetComponent<CapsuleCollider2D>().enabled = false;
        GameObject.Find("Balloon").GetComponent<CapsuleCollider2D>().enabled = false;
        yield return new WaitForSeconds(1f);
        anim.SetBool("IsDead", false);
        GameObject.Find("Balloon").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("Balloon").GetComponent<Animator>().SetBool("Redpop", false);
        GameObject.Find("Balloon").GetComponent<Animator>().SetBool("Yellowpop", false);
        GameObject.Find("Balloon").GetComponent<Animator>().SetBool("Greenpop", false);
        GetComponent<CapsuleCollider2D>().enabled = true;
        GameObject.Find("Balloon").GetComponent<CapsuleCollider2D>().enabled = true;
        transform.position = respawn;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        health = 3;
        respawn = GameObject.Find("MusicFXS").GetComponent<MusicFXS>().checkpoint;

        if (SceneManager.GetActiveScene().name == "Bonus" || SceneManager.GetActiveScene().name == "Bonus2" || SceneManager.GetActiveScene().name == "Bonus3" || SceneManager.GetActiveScene().name == "Bonus4" || SceneManager.GetActiveScene().name == "Bonus5")
        {
            has2Balloon = true;
            anim.SetBool("2Balloons", true);
            has3Balloon = true;
            anim.SetBool("3Balloons", true);
        }
        else
        {
            transform.position = respawn;
            //GameObject.Find("MusicFXS").GetComponent<MusicFXS>().levelSaver = SceneManager.GetActiveScene().buildIndex;
            GameObject.Find("MusicFXS").GetComponent<MusicFXS>().levelPlayed = SceneManager.GetActiveScene().buildIndex;
        }
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
                anim.SetBool("GoLeft", false);
            }
            else
            {
                if(Input.GetAxis("Horizontal") > 0)
                {
                    anim.SetBool("GoLeft", true);
                    anim.SetBool("GoRight", false);
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

            GameObject.Find("Balloonpopp").GetComponent<AudioSource>().Play();

            //if (SceneManager.GetActiveScene().name == "Bonus" || SceneManager.GetActiveScene().name == "Bonus2" || SceneManager.GetActiveScene().name == "Bonus3" || SceneManager.GetActiveScene().name == "Bonus4" || SceneManager.GetActiveScene().name == "Bonus5")
            //{
            
            respawn = GameObject.Find("MusicFXS").GetComponent<MusicFXS>().checkpoint;
                
            if (health == 2)
            {
                GameObject.Find("Heart3").SetActive(false);
                StartCoroutine(DeadAnimation());
                //transform.position = respawn;
            }
            else
            {
                if (health == 1)
                {
                    GameObject.Find("Heart2").SetActive(false);
                    StartCoroutine(DeadAnimation());
                    //transform.position = respawn;
                }
                else
                {
                    if (health == 0)
                    {
                        has2Balloon = false;
                        anim.SetBool("2Balloons", false);

                        has3Balloon = false;
                        anim.SetBool("3Balloons", false);

                        //GameObject.Find("MusicFXS").GetComponent<MusicFXS>().checkpoint = new Vector3(0, 0, 0);

                        SceneManager.LoadScene("LoseResult");
                    }
                }
            }

            if (has2Balloon == true)
            {
                anim.SetBool("2Balloons", false);
                has2Balloon = false;

                has3Balloon = false;
                anim.SetBool("3Balloons", false);
            }
            else
            {
                if (has3Balloon == true)
                {
                    anim.SetBool("3Balloons", false);
                    has3Balloon = false;

                    anim.SetBool("2Balloons", true);
                    has2Balloon = true;
                }
                else
                {
                    has2Balloon = false;
                    anim.SetBool("2Balloons", false);

                    has3Balloon = false;
                    anim.SetBool("3Balloons", false);

                }
            }

            if (SceneManager.GetActiveScene().name == "Bonus")
            {
                SceneManager.LoadScene("Gameplay");
            }
            else
            {
                if (SceneManager.GetActiveScene().name == "Bonus2")
                {
                    SceneManager.LoadScene("Gameplay2");
                }
                else
                {
                    if (SceneManager.GetActiveScene().name == "Bonus3")
                    {
                        SceneManager.LoadScene("Gameplay3");
                    }
                    else
                    {
                        if (SceneManager.GetActiveScene().name == "Bonus4")
                        {
                            SceneManager.LoadScene("Gameplay4");
                        }
                        else
                        {
                            if (SceneManager.GetActiveScene().name == "Bonus5")
                            {
                                SceneManager.LoadScene("Gameplay5");
                            }
                        }
                    }
                }
            }
        }

        if (collision.gameObject.layer == 6)
        {
            GameObject.Find("Jump").GetComponent<AudioSource>().Play();
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Checkpoint")
        {
            GameObject.Find("Checkpoint").GetComponent<AudioSource>().Play();

            collision.GetComponent<BoxCollider2D>().enabled = false;

            respawn = collision.transform.position;
            collision.GetComponent<Animator>().SetBool("isPointed", true);
        }

        if (collision.gameObject.tag == "Yellow")
        {
            has2Balloon = true;
            has3Balloon = false;
            anim.SetBool("2Balloons", true);
            GameObject.Find("PickBalloon").GetComponent<AudioSource>().Play();

            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Green")
        {
            if (has2Balloon == true)
            {
                has2Balloon = false;
                has3Balloon = true;
                anim.SetBool("3Balloons", true);
                GameObject.Find("PickBalloon").GetComponent<AudioSource>().Play();
                Destroy(collision.gameObject);

                StartCoroutine(BonusGameplayLoad());
            }
            else
            {
                anim.SetBool("2Balloons", true);
                has2Balloon = true;
                has3Balloon = false;
                Destroy(collision.gameObject);
            }
        }

        if (collision.gameObject.tag == "Finaldoor")
        {
            GameObject.Find("MusicFXS").GetComponent<MusicFXS>().countStar = health;

            if (SceneManager.GetActiveScene().name == "Bonus" || SceneManager.GetActiveScene().name == "Bonus2" || SceneManager.GetActiveScene().name == "Bonus3" || SceneManager.GetActiveScene().name == "Bonus4" || SceneManager.GetActiveScene().name == "Bonus5")
            {
                GameObject.Find("MusicFXS").GetComponent<MusicFXS>().levelSaver = SceneManager.GetActiveScene().buildIndex - 5;
            }
            else
            {
                GameObject.Find("MusicFXS").GetComponent<MusicFXS>().levelSaver = SceneManager.GetActiveScene().buildIndex;
            } 

            SceneManager.LoadScene("WinResult");
        }
    }
}
                                            