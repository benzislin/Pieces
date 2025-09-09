using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject optionsMenu;
    public AudioSource LessIsMore;
    public void Play()
    {
        LessIsMore.Play();
    }
    public Button PauseButton;

    void Start()
    {
        Button btn = PauseButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        pauseMenuUI.SetActive(false);
    }

    public void TaskOnClick()
    {
        GameIsPaused = true;
        Pause();
        Debug.Log("something");
    }
// Update is called once per frame
void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void resume()
    {
        pauseMenuUI.SetActive(false);
        optionsMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        LessIsMore.Play();
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        LessIsMore.Pause();
    }
    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}