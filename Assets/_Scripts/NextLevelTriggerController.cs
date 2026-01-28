using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelTriggerController : MonoBehaviour
{
    Coroutine endLvlCoroutine;

    bool readyToEndLvl = true;

    private void OnTriggerEnter(Collider other)
    {
        // 
        endLvlCoroutine = StartCoroutine(Timer());
    }

    private void OnTriggerExit(Collider other)
    {
        StopCoroutine(endLvlCoroutine);
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSecondsRealtime(2);

        if (readyToEndLvl)
        {
            LevelLoader.LoadNextLvl();
        }

    }
}
