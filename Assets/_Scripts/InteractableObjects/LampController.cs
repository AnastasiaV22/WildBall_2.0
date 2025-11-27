using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampController : InteractableObject
{

    [SerializeField] private bool isOn = false;
    [SerializeField] private GameObject lightPref;
    [SerializeField] private GameObject darkPref;

    private void Awake()
    {
        objectType = TypeOfInteractableObject.Lamp;

        if (isOn)
        {
            darkPref.SetActive(false);
            lightPref.SetActive(true);
        }
        else
        {
            darkPref.SetActive(true);
            lightPref.SetActive(false);
        }
    }

    public override void StartInteraction()
    {
        if (canBeUsed)
        {
            if (!isOn)
                OnLamp();
            else
                OffLamp();
            
        }
    }

    public override void EndInteraction()
    {

    }


    private void OffLamp()
    {
        darkPref.SetActive(true);
        lightPref.SetActive(false);
        isOn = false;

        canBeUsed = isSingleUse ? false : true;
    }

    private void OnLamp()
    {
        darkPref.SetActive(false);
        lightPref.SetActive(true);
        isOn = true;

        canBeUsed = isSingleUse ? false : true;
    }


}
