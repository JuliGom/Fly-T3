using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BalloonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        } */

        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Prick")
        {
            GameObject.Find("Player").GetComponent<PlayerMovement>().health -= 1;

            if (GameObject.Find("Player").GetComponent<PlayerMovement>().health == 2)
            {
                GameObject.Find("Heart3").SetActive(false);
                GameObject.Find("Player").transform.position = GameObject.Find("Player").GetComponent<PlayerMovement>().respawn;
            }
            else
            {
                if (GameObject.Find("Player").GetComponent<PlayerMovement>().health == 1)
                {
                    GameObject.Find("Heart2").SetActive(false);
                    GameObject.Find("Player").transform.position = GameObject.Find("Player").GetComponent<PlayerMovement>().respawn;
                }
                else
                {
                    if (GameObject.Find("Player").GetComponent<PlayerMovement>().health == 0)
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    }
                }
            }
        }
    }
}
