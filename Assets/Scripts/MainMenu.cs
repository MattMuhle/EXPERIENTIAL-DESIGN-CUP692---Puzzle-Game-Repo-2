using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string currentLevel;
    GameObject GameManager;

    public void Start()
    {

        currentLevel = SceneManager.GetActiveScene().name;

        if (currentLevel == "Win_Scene" || currentLevel == "Game_Over_Scene")
        {
            GameManager = GameObject.FindWithTag("GameManager");
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ReplayLevel()
    {
        if (GameManager != null)
        {
            string previousLevel = GameManager.GetComponent<Script_GameManager>().currentLevel;
            SceneManager.LoadScene(previousLevel);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
