using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    float moveSpeed;
    Vector2 offset;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        offset = new Vector2(Time.time * moveSpeed, 0);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
