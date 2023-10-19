/*using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;    */

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

        if (SceneManager.GetActiveScene().name == "Gameplay")
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

        //Debug.Log(Time.timeScale);

        /*if (SceneManager.GetActiveScene().name == "Gameplay")
        {
            if (GameObject.Find("PopupBackground").GetComponent<Image>().enabled == true)
            {
                Time.timeScale = 0;
            }
        }*/

        if (SceneManager.GetActiveScene().name == "Cinematica")
        {
            if (Input.GetKeyDown("space"))
            {
                SceneManager.LoadScene("Gameplay");
            }
        }
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Cinematica");
    }

    public void PlayAgainButton()
    {
        SceneManager.LoadScene("Gameplay");
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
