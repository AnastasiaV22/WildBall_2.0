using UnityEngine;

public enum TypeOfInteractableObject
{
    Door,
    Gate,
    Lamp,
    Lever,
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
}
