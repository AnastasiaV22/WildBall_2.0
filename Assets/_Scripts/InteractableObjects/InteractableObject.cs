using UnityEngine;
using UnityEngine.Events;

public enum TypeOfInteractableObject
{
    Door,
    Gate,
    Lamp,
    Lever,
    Portal,
    None
}


public abstract class InteractableObject : MonoBehaviour
{
    internal TypeOfInteractableObject objectType = TypeOfInteractableObject.None;

    // Активируется ли один раз
    [SerializeField] internal bool isSingleUse = true;
    // может ли быть использована сейчас
    [SerializeField] internal bool canBeUsed = true;
    // активирована ли 
    [SerializeField] internal bool isUsed = false;

    internal bool inUse = false;

    [SerializeField] internal bool activateByTrigger;
    [SerializeField] internal TriggerController triggerController;

    internal AudioSource audioSource;

    public UnityEvent UsageStarted;
    public UnityEvent UsageEnded;

    private void Awake()
    {


    }

    private void Start()
    {
        audioSource = GetComponentInChildren<AudioSource>();
        
        if (activateByTrigger && triggerController != null)
        {
           
            triggerController.TriggerActivated.AddListener(StartInteraction);
            triggerController.TriggerDeactivated.AddListener(EndInteraction);
        }
        else
        {
        }
    }

    public abstract void StartInteraction();

    public abstract void EndInteraction();

    internal void StartUsing()
    {
        inUse = true;
        UsageStarted?.Invoke();
    }
    internal void EndUsing()
    {
        inUse = false; 
        isUsed = !isUsed;
        UsageEnded?.Invoke();
    }
}
