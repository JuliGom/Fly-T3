using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProjectileAttack : MonoBehaviour
{
    public GameObject Projectile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackMoment()
    {
        if (SceneManager.GetActiveScene().name == "Gameplay3" || SceneManager.GetActiveScene().name == "Gameplay5" || SceneManager.GetActiveScene().name == "Bonus3" || SceneManager.GetActiveScene().name == "Bonus5")
        {
            GetComponent<AudioSource>().Play();
        }
        Instantiate(Projectile, transform.position, Projectile.transform.rotation);
    }
}
