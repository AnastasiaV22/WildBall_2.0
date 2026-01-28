using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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


    [SerializeField] GameObject player;
    [SerializeField] InputController inputController;


    public void StartGame()
    {
        Time.timeScale = 1;
        inputController.EnableGameInput();

    }
    public void EndGame()
    {

        //анимация смерти
        //inGameUI.ShowGameoverPanel();

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
