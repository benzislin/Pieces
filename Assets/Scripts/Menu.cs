using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject levelMenu;
    public AudioSource music;
    public GameObject Anim;
    public GameObject first;
    public GameObject second;
    public GameObject third;
    public Text cycleText;
    int cycle;
    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        levelMenu.SetActive(false);
    }
    public void Play()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
        levelMenu.SetActive(true);
        music.Stop();
    }
    public void HowToPlay()
    {
        SceneManager.LoadScene(1);
        music.Stop();
    }

    public void Options()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    public void Back()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        levelMenu.SetActive(false);
    }
    public void CycleL()
    {
        if(first.activeSelf == true)
        {
            first.SetActive(false);
            second.SetActive(false);
            third.SetActive(true);
            return;
        }
        if (second.activeSelf == true)
        {
            first.SetActive(true);
            second.SetActive(false);
            third.SetActive(false);
            return;
        }
        if (third.activeSelf == true)
        {
            first.SetActive(false);
            second.SetActive(true);
            third.SetActive(false);
            return;
        }
    }
    public void CycleR()
    {
        if (first.activeSelf == true)
        {
            first.SetActive(false);
            second.SetActive(true);
            third.SetActive(false);
            return;
        }
        if (second.activeSelf == true)
        {
            first.SetActive(false);
            second.SetActive(false);
            third.SetActive(true);
            return;
        }
        if (third.activeSelf == true)
        {
            first.SetActive(true);
            second.SetActive(false);
            third.SetActive(false);
            return;
        }
    }
    private void Update()
    {
        if(mainMenu.activeSelf == false)
        {
            Anim.SetActive(false);
        }
        else
        {
            Anim.SetActive(true);
        }
        if(first.activeSelf == true)
        {
            cycle = 1;
        }
        if (second.activeSelf == true)
        {
            cycle = 2;
        }
        if (third.activeSelf == true)
        {
            cycle = 3;
        }
        cycleText.text = cycle + "/3";
    }

}
