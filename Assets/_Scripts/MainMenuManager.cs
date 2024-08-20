using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject levelSelect;
    public GameObject credits;
    public int firstLevelIndex = 1;
    public void QuitGame()
    {
        Application.Quit();
    }
    public void GoToLevelSelect()
    {
        mainMenu.SetActive(false);
        credits.SetActive(false);
        levelSelect.SetActive(true);
    }
    public void goToCredits()
    {
        mainMenu.SetActive(false);
        levelSelect.SetActive(false);
        credits.SetActive(true);
    }
    public void backToMainMenu()
    {
        credits.SetActive(false);
        levelSelect.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void goToLevel(int levelNumber)
    {
        SceneManager.LoadScene(levelNumber+firstLevelIndex);
    }
}
