using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LevelManager : MonoBehaviour
{
    IEnumerator MiCorrutina()
    {
        yield return new WaitForSeconds(25f);
        SceneManager.LoadScene("Gameplay");
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        if (SceneManager.GetActiveScene().name == "Gameplay" || SceneManager.GetActiveScene().name == "Gameplay2" || SceneManager.GetActiveScene().name == "Gameplay3" || SceneManager.GetActiveScene().name == "Gameplay4" || SceneManager.GetActiveScene().name == "Gameplay5" || SceneManager.GetActiveScene().name == "Bonus" || SceneManager.GetActiveScene().name == "Bonus2" || SceneManager.GetActiveScene().name == "Bonus3" || SceneManager.GetActiveScene().name == "Bonus4" || SceneManager.GetActiveScene().name == "Bonus5")
        {
            GameObject.Find("Options").GetComponent<Canvas>().enabled = false;
        }

        if (SceneManager.GetActiveScene().name == "Cinematica")
        {
            StartCoroutine(MiCorrutina());
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (SceneManager.GetActiveScene().name == "Cinematica")
        {
            if (Input.GetKeyDown("space") || Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("Gameplay");
            }

        }

        /*if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            if (Input.GetKeyDown("1"))
            {
                SceneManager.LoadScene("Gameplay");
            }
            if (Input.GetKeyDown("2"))
            {
                SceneManager.LoadScene("Gameplay2");
            }
            if (Input.GetKeyDown("3"))
            {
                SceneManager.LoadScene("Bonus");
            }
            if (Input.GetKeyDown("4"))
            {
                SceneManager.LoadScene("Bonus2");
            }
        } */
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Cinematica");
    }

    public void PlayAgainButton()
    {
        GameObject.Find("MusicFXS").GetComponent<MusicFXS>().checkpoint = new Vector3(0, 0, 0);
        SceneManager.LoadScene("Map");
    }


    public void QuitButton()
    {
        Application.Quit();
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OptionsMenuButton()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void MapMenu()
    {
        SceneManager.LoadScene("Map");
    }

    public void CreditsOnButton()
    {
        Animator anim = GameObject.Find("Ticket").GetComponent<Animator>();

        if (SceneManager.GetActiveScene().name == "OptionsMenu")
        {
            anim.SetBool("CreditsOn", true);
        }
    }
    public void CreditsOffButton()
    {
        Animator anim = GameObject.Find("Ticket").GetComponent<Animator>();

        if (SceneManager.GetActiveScene().name == "OptionsMenu")
        {
            anim.SetBool("CreditsOn", false);
        }
    }

    public void PauseButton()
    {
        if (Time.timeScale == 0)
        {
            GameObject.Find("Options").GetComponent<Canvas>().enabled = false;
            Time.timeScale = 1;
        }
        else
        {
            GameObject.Find("Options").GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0;
        }
    }

    public void TutorialMessage()
    {
        GameObject.Find("PopupBackground").GetComponent<Image>().enabled = false;
        GameObject.Find("Message").SetActive(false);
        Time.timeScale = 1;
    }
}