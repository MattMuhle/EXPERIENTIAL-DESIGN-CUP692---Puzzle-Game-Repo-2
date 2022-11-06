using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene1Script : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "ReloadScene")
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            // SceneManager.LoadScene("Game_Over_Scene");
            SceneManager.LoadScene("Level1");
        }

    }
}
