using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    [SerializeField] Button[] buttons;

    [SerializeField] GameObject UIBGPanel;

    [SerializeField] GameObject inGameUIPanel;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject GameoverPanel;

    [SerializeField] GameObject messageField;
    [SerializeField] Text messageText;

    void Awake()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;
            buttons[index].onClick.AddListener(() => OnButtonClick((buttons[index]).name));
        }

    }
        

    private void Start()
    {
        gameManager.PlayerDied.AddListener(ShowGameoverPanel);

    }


    public UnityEvent GamePaused;


    // ----------------- MENU ---------------------------

    void OnButtonClick(string name)
    {
        switch (name)
        {
            case "MainMenuButton":
                
                SceneLoader.LoadMainMenuScene();
                Time.timeScale = 1;
                
                break;

            case "RestartButton":
                
                SceneLoader.ReloadScene();
                
                gameManager.StartGame();

                break;

            case "PlayButton":
                
                pausePanel.SetActive(false);
                inGameUIPanel.SetActive(true);

                gameManager.StartGame();
                break;

            case "PauseButton":
                
                pausePanel.SetActive(true);
                inGameUIPanel.SetActive(false);

                GamePaused?.Invoke();

                break;

            case "SettingsButton":

                break;

            case "NextLvlButton":
                
                gameManager.StartGame();
                
                break;

            default:
                break;
        }

    }

    public void ShowGameoverPanel()
    {
        Debug.Log($"{inGameUIPanel.IsUnityNull()}, {inGameUIPanel.activeSelf}");
        StartCoroutine(ShowGameoverPanelCoroutine());
    }

    IEnumerator ShowGameoverPanelCoroutine()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        inGameUIPanel.SetActive(false);
        GameoverPanel.SetActive(true);

    }

    public void ShowSuccsesEndGamePanel()
    {

    }

    // ------------------ Game -----------------------



    public void OpenDialogWindow()
    {
        Debug.Log("Окно диалога открыто");
        messageField.SetActive(true);
    }

    public void CloseDialogWindow()
    {
        Debug.Log("Окно диалога закрыто");
        messageField.SetActive(false);

    }




    // ----------------------- view --------------------------------


    [SerializeField] Text textMessagePrefab;

    [SerializeField] Font font;
    [SerializeField] TextAlignment textAlignment;
    [SerializeField] Color textColor;
    //[SerializeField] int fontSize = 15;


    private Text CreateTextObject(GameObject field)
    {
        if (field == null)
        {
            return null;
        }

        Text text = Instantiate(textMessagePrefab, field.transform);

        /*
        text.transform.SetParent(field.transform);
        text.text = "";
        text.fontSize = fontSize;
        text.font = font ?? text.font;
        if (textColor != null)
            text.color = textColor;
        else
            text.color = Color.black;
        */

        return text;
    }

    private void ClearTextObject(GameObject field)
    {
        field.GetComponentInChildren<Text>().text = "";
    }

    public void UpdateInteractionMessageText(TypeOfInteractableObject objectType, bool interactable)
    {
        if (!messageField.activeSelf)
        {
            OpenDialogWindow();
        }

        Debug.Log($"message for {objectType}");

        if (interactable)
        {

            Debug.Log($"{messageText.IsUnityNull()} Для взаимодействия с <i>{objectType}</i> нажми <i>[F]</i>");
            messageText.text = $"Для взаимодействия с <i>{objectType}</i> нажми <i>[F]</i>";
        }
        else if (objectType == TypeOfInteractableObject.Door)
        {
            Debug.Log($"Закрыто");
            messageText.text = $"Закрыто";
        }

    }

    public void UpdateTextInField(Text textField, string type)
    {

    }
}
