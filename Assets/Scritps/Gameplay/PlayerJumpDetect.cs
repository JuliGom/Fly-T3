using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpDetect : MonoBehaviour
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
        //if (collision.gameObject.layer == 6)
        if (GameObject.Find("Player").GetComponent<BalloonMovement>().isGrounded == true)
        {
            GameObject.Find("Jump").GetComponent<AudioSource>().Play();
        }
    }
}
