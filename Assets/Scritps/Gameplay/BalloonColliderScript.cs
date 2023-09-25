using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonColliderScript : MonoBehaviour
{
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
