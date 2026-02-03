using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : InteractableObject
{

    [SerializeField] private bool isOn = false;

    [SerializeField] private bool hasDeactivationAction;

    [SerializeField] private GameObject triggerArea;
    [SerializeField] private GameObject portal;


    private void Awake()
    {
        objectType = TypeOfInteractableObject.Portal;

        if (isOn)
        {
            triggerArea.SetActive(true);
            portal.SetActive(true);
        }
        else
        {
            triggerArea.SetActive(false);
            portal.SetActive(false);
            
        }
    }

    public override void StartInteraction()
    {
        if (canBeUsed)
        {
            if (!isOn)
                PortalOn();
            else
                PortalOff();
            
        }
    }

    public override void EndInteraction()
    {

    }


    private void PortalOff()
    {
        triggerArea.SetActive(false);
        portal.SetActive(false);
        isOn = false;

        canBeUsed = isSingleUse ? false : true;
    }

    private void PortalOn()
    {
        triggerArea.SetActive(true);
        portal.SetActive(true);
        isOn = true;

        canBeUsed = isSingleUse ? false : true;
    }


}
