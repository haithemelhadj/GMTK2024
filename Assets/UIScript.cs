using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    //singelton
    public static UIScript instance;
    //
    public GameObject pausePanel;
    public GameObject winPanel;
    public bool paused;
    //

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    private void Start()
    {
        Time.timeScale = 1f;
    }
    public void pause()
    {
        if (paused)
        {
            Time.timeScale = 1f;
            paused = false;
            pausePanel.SetActive(false);
        }
        else
        {
            Time.timeScale = 0f;
            paused = true;
            pausePanel.SetActive(true);
        }
    }
    public void win()
    {
        winPanel.SetActive(true);
        pausePanel.SetActive(false);
        Time.timeScale = 0f;
    }
    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
