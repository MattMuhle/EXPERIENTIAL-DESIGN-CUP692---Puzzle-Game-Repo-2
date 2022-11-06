using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSceneScript : MonoBehaviour
{
    public void RetryGame()
    {
        SceneManager.LoadScene("Boss_Arena");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
