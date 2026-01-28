using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    static public void LoadNextLvl()
    {
        int index = SceneManager.GetActiveScene().buildIndex;

        if (index < SceneManager.sceneCountInBuildSettings - 1) //+ lvl available
        {

            //открытие нового уровня

            SceneManager.LoadScene(index + 1);

        }
        else
        {
            SceneManager.LoadScene(0);
        }

    }

    static public void LoadLvlByBildIndex(int index)
    {
        SceneManager.LoadScene(index);

    }
}
