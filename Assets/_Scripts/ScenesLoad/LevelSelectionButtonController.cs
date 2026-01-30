using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionButtonController : MonoBehaviour
{

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        if (true) //если уровень открыт
        {
            string buttonText = GetComponentInChildren<TextMeshProUGUI>().text;
            if (Regex.IsMatch(buttonText, @"^\d+$"))
            {
                int index = Convert.ToInt32(buttonText);
                SceneLoader.LoadSceneByBildIndex(index);
            }else if (buttonText == "test")
            {
                SceneLoader.LoadTestScene();
            }
        }
    }

    void ActivateButton()
    {
        GetComponent<Button>().interactable = true;
        GetComponentInChildren<Image>().gameObject.SetActive(false);
    }

}
