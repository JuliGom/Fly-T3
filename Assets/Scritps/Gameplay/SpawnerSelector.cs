using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnerSelector : MonoBehaviour
{
    public float animationDelay;
    public int randomAnimator;

    //public GameObject[] monkeySelector = new GameObject[2];
    public Animator[] monkeyAnimators = new Animator[2];

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Bonus" || SceneManager.GetActiveScene().name == "Bonus2" || SceneManager.GetActiveScene().name == "Bonus3" || SceneManager.GetActiveScene().name == "Bonus4" || SceneManager.GetActiveScene().name == "Bonus5")
        {
            animationDelay = Random.Range(0.25f, 1f);
        }
        else
        {
            animationDelay = Random.Range(1f, 3f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        animationDelay -= Time.deltaTime;
        
        if (animationDelay < 0)
        {
            randomAnimator = Random.Range(0, monkeyAnimators.Length);
            
            if (randomAnimator == 0)
            {
                monkeyAnimators[0].SetBool("Attack", true);
                monkeyAnimators[1].SetBool("Attack", false);
            }
            else
            {
                monkeyAnimators[0].SetBool("Attack", false);
                monkeyAnimators[1].SetBool("Attack", true);
            }
            
            if (SceneManager.GetActiveScene().name == "Bonus" || SceneManager.GetActiveScene().name == "Bonus2" || SceneManager.GetActiveScene().name == "Bonus3" || SceneManager.GetActiveScene().name == "Bonus4" || SceneManager.GetActiveScene().name == "Bonus5")
            {
                animationDelay = Random.Range(0.25f, 1f);
            }
            else
            {
                animationDelay = Random.Range(1f, 3f);
            }
        }
    }
}
