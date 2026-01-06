using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using WildBall.Inputs;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject messageField;

    [SerializeField] Text textMessagePrefab;

    [SerializeField] Font font;
    [SerializeField] TextAlignment textAlignment;
    [SerializeField] Color textColor;
    [SerializeField] int fontSize = 15;

    Text messageText;


    private void Awake()
    {
        messageText = CreateTextObject(messageField);

    }

    private Text CreateTextObject(GameObject field)
    {
        if (field == null) { 
            return null;
        }

        Text text = Instantiate(textMessagePrefab, messageField.transform);
        

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

    public void OpenDialogWindow()
    {

        Debug.Log("Окно диалога открыто");
        messageField.SetActive(true);
    }

    public void CloseDialogWindow()
    {
        Debug.Log("Окно диалога закрыто");
        messageText.text = "";
        messageField.SetActive(false);

    }

    public void UpdateMessageText(TypeOfInteractableObject objectType, bool interactable)
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
}
