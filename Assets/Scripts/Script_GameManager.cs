using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_GameManager : MonoBehaviour
{
    public string newLevel, currentLevel;

    public void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void Update()
    {
        newLevel = SceneManager.GetActiveScene().name;
        if (newLevel == "Main_Menu_Scene" || newLevel == "Win_Scene" || newLevel == "Game_Over_Scene") // DONT GET CURRENT LEVEL NAME IF IN THIS SCENES
        {
            return;
        }
        currentLevel = SceneManager.GetActiveScene().name;
    }

    //    public class reload : monobehaviour
    //    {
    //        void update()
    //        {
    //            if (input.getkeydown(keycode.r))
    //            {
    //                scene scene = scenemanager.getactivescene(); scenemanager.loadscene(scene.name);
    //                scenemanager.loadscene(scenemanager.getactivescene().buildindex);
    //            }
    //        }
    //    }

    //}
}
