using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject scoresMenu;
    public GameObject aboutMenu;

    public Text highscoreText;

    public string gameScene;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
        highscoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("HighScore");
        PlayerPrefs.SetInt("Lives", 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void OpenOptions()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void CloseOptions()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void OpenScores()
    {
        mainMenu.SetActive(false);
        scoresMenu.SetActive(true);
    }

    public void CloseScores()
    {
        mainMenu.SetActive(true);
        scoresMenu.SetActive(false);
    }

    public void OpenAbout()
    {
        mainMenu.SetActive(false);
        aboutMenu.SetActive(true);
    }

    public void CloseAbout()
    {
        mainMenu.SetActive(true);
        aboutMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quit game");

        Application.Quit();
    }
}
