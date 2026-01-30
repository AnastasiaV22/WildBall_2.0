using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    static public void LoadNextLvl()
    {
        int index = SceneManager.GetActiveScene().buildIndex;

        if (index < (SceneManager.sceneCountInBuildSettings - 1) - 1) //+ lvl available
        {

            //открытие нового уровня

            LoadSceneByBildIndex(index + 1);
        }
        else
        {
            LoadMainMenuScene();
        }

    }

    static public void ReloadScene()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }

    static public void LoadSceneByBildIndex(int index)
    {
        SceneManager.LoadScene(index);

    }

    static public void LoadMainMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    static public void LoadTestScene()
    {
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }
}
