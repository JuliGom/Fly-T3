using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MusicFXS : MonoBehaviour
{
    public static MusicFXS instance;

    public Vector3 checkpoint;

    public int countStar;
    public int levelSaver;
    public int levelPlayed;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Gameplay" || SceneManager.GetActiveScene().name == "Gameplay2" || SceneManager.GetActiveScene().name == "Gameplay3" || SceneManager.GetActiveScene().name == "Gameplay4" || SceneManager.GetActiveScene().name == "Gameplay5")
        {
            checkpoint = GameObject.Find("Player").GetComponent<PlayerMovement>().respawn;
        }
    }
}
