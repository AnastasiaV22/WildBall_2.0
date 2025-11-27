using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WildBall.Inputs;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject messageField;

    [SerializeField] Font font;
    [SerializeField] TextAlignment textAlignment;
    [SerializeField] Color textColor;

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

        Text text = field.AddComponent<Text>();
        text.text = "";

        text.font = font ?? text.font;
        if (textColor != null)
            text.color = textColor;
        else
            text.color = Color.black;

        return text;
    }

    public void OpenTextWindow()
    {

    }

    public void ShowHelpMessage(TypeOfInteractableObject objectType, bool interactable)
    {
        messageField.SetActive(true);

        if (interactable)
        {
            messageText.text = $"Для взаимодействия с <i>{objectType}</i> нажми <i>[{GlobalStringVars.INTERACTION_BUTTON}]</i>";
        } 
        else if (objectType == TypeOfInteractableObject.Door)
        {
            messageText.text = $"Закрыто";
        }
         
    }
    public void HideHelpMessage()
    {
        messageText.text = "";
        messageField.SetActive(false);
    }
}
