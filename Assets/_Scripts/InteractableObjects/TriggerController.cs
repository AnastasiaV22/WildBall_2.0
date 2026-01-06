using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum TriggerType
{
    Lever,
    Button,
    None
}

public class TriggerController : MonoBehaviour
{
    [SerializeField] TriggerType triggerType;

    public UnityEvent TriggerActivated;
    public UnityEvent TriggerDeactivated;



    private bool isUsed;


    private void Awake()
    { 
        TriggerActivated = new UnityEvent();
        TriggerDeactivated = new UnityEvent();
        isUsed = false;
    }
    
    public void UseTrigger()
    {
        ActivateTrigger();
    }

    private void ActivateTrigger()
    {
        TriggerActivated.Invoke();
        ChangeTriggerState(); 
        Debug.Log($"{triggerType} TriggerActivated");
    }

    private void DeactivateTrigger()
    {
        TriggerDeactivated?.Invoke();
        ChangeTriggerState();
        Debug.Log($"{triggerType} TriggerDeactivated");
    }

    private void ChangeTriggerState()
    {
        isUsed = !isUsed;
    }

}
