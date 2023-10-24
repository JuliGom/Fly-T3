using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Performance : MonoBehaviour
{
    public Image sprite1;
    public Image sprite2;
    public Image sprite3;
    public int gameplayPerformance;
    public int sceneBuildIndex;

    // Start is called before the first frame update
    void Start()
    {
        gameplayPerformance = GameObject.Find("MusicFXS").GetComponent<MusicFXS>().countStar;
        sceneBuildIndex = GameObject.Find("MusicFXS").GetComponent<MusicFXS>().levelSaver;

        if (gameplayPerformance == 1)
        {
            sprite1.enabled = true;
            sprite2.enabled = false;
            sprite3.enabled = false;
        }
        else
        {
            if (gameplayPerformance == 2)
            {
                sprite1.enabled = false;
                sprite2.enabled = true;
                sprite3.enabled = false;
            }
            else
            {
                sprite1.enabled = false;
                sprite2.enabled = false;
                sprite3.enabled = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextLevel()
    {
        if (sceneBuildIndex == 10)
        {
            SceneManager.LoadScene("Map");
        }
        else
        {
            SceneManager.LoadScene(sceneBuildIndex + 1);
        }
    }
}
