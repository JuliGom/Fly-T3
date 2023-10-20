using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Bonus")
        {
            //transform.Rotate(0, 0, 45);
            transform.Rotate(0, 0, Random.Range(-70, 70));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Bonus")
        {
            transform.Translate(Vector2.left * 12f * Time.deltaTime);
            Destroy(gameObject, 3f);
        }
        else
        {
            transform.Translate(Vector2.left * 5f * Time.deltaTime);
            Destroy(gameObject, 5f);
        }
    }
}
