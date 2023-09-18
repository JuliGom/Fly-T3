using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //anim.SetBool("Forward", true);
        //transform.position += transform.forward * Time.deltaTime * 5f;
        transform.Translate(Vector2.left * 2f * Time.deltaTime);
        Destroy(gameObject, 6f);
    }
}
