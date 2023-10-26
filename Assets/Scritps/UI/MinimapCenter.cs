using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCenter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, -0.01f, 0.01f);
        transform.position = pos;
    }
}
