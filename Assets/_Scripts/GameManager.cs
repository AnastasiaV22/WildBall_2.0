using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using WildBall.Inputs;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private GameManager() { }
    public static GameManager GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        uiController.GamePaused.AddListener(OnGamePause);
    }

    [SerializeField] GameObject player;
    [SerializeField] InputController inputController;
    [SerializeField] UIController uiController;

    public UnityEvent PlayerDied;
    //ityEvent GameStarted;
    //UnityEvent GameEnded;
    //UnityEvent Saving;


    public void StartGame()
    {
        Time.timeScale = 1;
        inputController.EnableGameInput();

    }

    public void EndGame(bool endedSucsesful)
    {
        inputController.DisableGameInput();
        Time.timeScale = 0;

        if (!endedSucsesful)
        {
            //анимация смерти
            // ожидание конца анимации 
            PlayerDied.Invoke();
        }



    }

    private void OnGamePause()
    {
        Time.timeScale = 0;
        inputController.DisableGameInput();
    }


    public void LoadGame()
    {

    }

    public void SaveGame()
    {

    }
}
