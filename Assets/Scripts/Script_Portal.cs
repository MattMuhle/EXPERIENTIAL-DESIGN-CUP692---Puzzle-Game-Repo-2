using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_Portal : MonoBehaviour
{
    private bool collidedWithPlayer1, collidedWithPlayer2;
    [SerializeField] string nextSceneName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player1")
        {
            collidedWithPlayer1 = true;
            CheckToLoadNextScene();
        }

        if (other.transform.tag == "Player2")
        {
            collidedWithPlayer2 = true;
            CheckToLoadNextScene();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player1")
        {
            collidedWithPlayer1 = false;
        }

        if (other.transform.tag == "Player2")
        {
            collidedWithPlayer2 = false;
        }
    }

    private void CheckToLoadNextScene()
    {
        if (nextSceneName == null)
        {
            Debug.Log("NextSceneName Needed!");
            return;
        }
        if (collidedWithPlayer1 && collidedWithPlayer2)
        {
            SceneManager.LoadScene(nextSceneName, LoadSceneMode.Single);
        }
    }
}
