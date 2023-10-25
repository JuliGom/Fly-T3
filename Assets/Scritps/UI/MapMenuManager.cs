//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapMenuManager : MonoBehaviour
{
    public Button[] mapMenuButtons = new Button[5]; 

    public int sceneIndexPlayed = 0;
    public int sceneIndexWin = 0;

    // Start is called before the first frame update
    void Start()
    {
        sceneIndexPlayed = GameObject.Find("MusicFXS").GetComponent<MusicFXS>().levelPlayed;
        sceneIndexWin = GameObject.Find("MusicFXS").GetComponent<MusicFXS>().levelSaver;

        if (sceneIndexWin == sceneIndexPlayed)
        {
            sceneIndexPlayed = sceneIndexPlayed + 1;
        }

        if (sceneIndexWin == 10)
        {
            sceneIndexPlayed = 0;
        }

        switch (sceneIndexPlayed)
        {
            case 0:
                mapMenuButtons[0].interactable = true;
                //Level 1 ON
                break;
            case 6:
                mapMenuButtons[0].interactable = true;
                //Level 1 ON
                break;
            case 7:
                mapMenuButtons[1].interactable = true;
                //Level 2 ON
                break;
            case 8:
                mapMenuButtons[2].interactable = true;
                //Level 3 ON
                break;
            case 9:
                mapMenuButtons[3].interactable = true;
                //Level 4 ON
                break;             
            case 10:
                mapMenuButtons[4].interactable = true;
                //Level 5 ON
                break;
        }
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void LoadLevel()
    {
        GameObject.Find("MusicFXS").GetComponent<MusicFXS>().checkpoint = new Vector3(0, 0, 0);

        if (sceneIndexPlayed == 0)
        {
            SceneManager.LoadScene("Gameplay");
        }
        else
        {
            SceneManager.LoadScene(sceneIndexPlayed);
        }
    }
}
