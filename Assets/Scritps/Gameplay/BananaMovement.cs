using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BananaMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Bonus" || SceneManager.GetActiveScene().name == "Bonus2" || SceneManager.GetActiveScene().name == "Bonus3" || SceneManager.GetActiveScene().name == "Bonus4" || SceneManager.GetActiveScene().name == "Bonus5")
        {
            transform.Rotate(0, 0, Random.Range(-70, 70));
        }
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(Vector3.up * 30f * Time.deltaTime);
        transform.Rotate(Vector3.forward * 30f * Time.deltaTime);

        if (SceneManager.GetActiveScene().name == "Bonus" || SceneManager.GetActiveScene().name == "Bonus2" || SceneManager.GetActiveScene().name == "Bonus3" || SceneManager.GetActiveScene().name == "Bonus4" || SceneManager.GetActiveScene().name == "Bonus5")
        {
            transform.Translate(Vector2.left * 15f * Time.deltaTime);
            Destroy(gameObject, 2f);
        }
        else
        {
            transform.Translate(Vector2.left * 10f * Time.deltaTime);
            Destroy(gameObject, 3f);
        }
    }
}
