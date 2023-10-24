using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BalloonColliderScript : MonoBehaviour
{   
    IEnumerator DeadAnimation()
    {
        GameObject.Find("Player").GetComponent<Animator>().SetBool("IsDead", true);

        if (GameObject.Find("Player").GetComponent<PlayerMovement>().has2Balloon == true)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<Animator>().SetBool("Yellowpop",true);
        }
        else
        {
            if (GameObject.Find("Player").GetComponent<PlayerMovement>().has3Balloon == true)
            {
                GetComponent<SpriteRenderer>().enabled = true;
                GetComponent<Animator>().SetBool("Greenpop", true);
            }
            else
            {
                GetComponent<SpriteRenderer>().enabled = true;
                GetComponent<Animator>().SetBool("Redpop", true);
            }
        }

        GameObject.Find("Player").GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<CapsuleCollider2D>().enabled = false;
        yield return new WaitForSeconds(1f);
        GameObject.Find("Player").GetComponent<Animator>().SetBool("IsDead", false);
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Animator>().SetBool("Redpop", false);
        GetComponent<Animator>().SetBool("Yellowpop", false);
        GetComponent<Animator>().SetBool("Greenpop", false);
        GameObject.Find("Player").GetComponent<CapsuleCollider2D>().enabled = true;
        GetComponent<CapsuleCollider2D>().enabled = true;
        GameObject.Find("Player").transform.position = GameObject.Find("Player").GetComponent<PlayerMovement>().respawn;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Prick")
        {
            GameObject.Find("Player").GetComponent<PlayerMovement>().health -= 1;

            GameObject.Find("Balloonpopp").GetComponent<AudioSource>().Play();

            /*if (SceneManager.GetActiveScene().name == "Bonus")
            {
                GameObject.Find("Player").GetComponent<PlayerMovement>().respawn = GameObject.Find("MusicFXS").GetComponent<MusicFXS>().checkpoint;
                SceneManager.LoadScene("Gameplay");
            } */

            GameObject.Find("Player").GetComponent<PlayerMovement>().respawn = GameObject.Find("MusicFXS").GetComponent<MusicFXS>().checkpoint;

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


            if (GameObject.Find("Player").GetComponent<PlayerMovement>().health == 2)
            {
                GameObject.Find("Heart3").SetActive(false);
                StartCoroutine(DeadAnimation());

                //GameObject.Find("Player").transform.position = GameObject.Find("Player").GetComponent<PlayerMovement>().respawn;
            }
            else
            {
                if (GameObject.Find("Player").GetComponent<PlayerMovement>().health == 1)
                {
                    GameObject.Find("Heart2").SetActive(false);
                    StartCoroutine(DeadAnimation());

                    //GameObject.Find("Player").transform.position = GameObject.Find("Player").GetComponent<PlayerMovement>().respawn;
                }
                else
                {
                    if (GameObject.Find("Player").GetComponent<PlayerMovement>().health == 0)
                    {
                        GameObject.Find("Player").GetComponent<PlayerMovement>().has2Balloon = false;
                        GameObject.Find("Player").GetComponent<Animator>().SetBool("2Balloons", false);

                        GameObject.Find("Player").GetComponent<PlayerMovement>().has3Balloon = false;
                        GameObject.Find("Player").GetComponent<Animator>().SetBool("3Balloons", false);

                        //GameObject.Find("MusicFXS").GetComponent<MusicFXS>().checkpoint = new Vector3(0, 0, 0);

                        SceneManager.LoadScene("LoseResult");
                    }
                }
            }

            //StartCoroutine(DeadAnimation());

            if (GameObject.Find ("Player").GetComponent<PlayerMovement>().has2Balloon == true)
            {
                GameObject.Find("Player").GetComponent<Animator>().SetBool("2Balloons", false);
                GameObject.Find("Player").GetComponent<PlayerMovement>().has2Balloon = false;

                GameObject.Find("Player").GetComponent<PlayerMovement>().has3Balloon = false;
                GameObject.Find("Player").GetComponent<Animator>().SetBool("3Balloons", false);
            }
            else
            {
                if (GameObject.Find("Player").GetComponent<PlayerMovement>().has3Balloon == true)
                {
                    GameObject.Find("Player").GetComponent<Animator>().SetBool("3Balloons", false);
                    GameObject.Find("Player").GetComponent<PlayerMovement>().has3Balloon = false;

                    GameObject.Find("Player").GetComponent<Animator>().SetBool("2Balloons", true);
                    GameObject.Find("Player").GetComponent<PlayerMovement>().has2Balloon = true;
                }
                else
                {
                    GameObject.Find("Player").GetComponent<PlayerMovement>().has2Balloon = false;
                    GameObject.Find("Player").GetComponent<Animator>().SetBool("2Balloons", false);

                    GameObject.Find("Player").GetComponent<PlayerMovement>().has3Balloon = false;
                    GameObject.Find("Player").GetComponent<Animator>().SetBool("3Balloons", false);
                }
            }
        }
    }
}
