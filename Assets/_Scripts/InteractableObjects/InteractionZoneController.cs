using UnityEngine;
using WildBall.Inputs;

public class InteractionZoneController : MonoBehaviour
{

    InteractionManager interactionManager;

    [SerializeField] InteractableObject parentObject;

    private void Awake()
    {
        parentObject = GetComponentInParent<InteractableObject>();
        interactionManager = FindObjectOfType<InteractionManager>();

        parentObject.UsageStarted.AddListener(DisableInteractionArea);
        parentObject.UsageEnded.AddListener(EnableInteractionArea);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            interactionManager.AddNewInteractableObject(parentObject);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            interactionManager.RemoveInteractableObject(parentObject);
        }

    }

    private void DisableInteractionArea()
    {
        interactionManager.RemoveInteractableObject(parentObject);
        GetComponent<Collider>().enabled = false;
    }

    private void EnableInteractionArea()
    {
        if ((parentObject.isSingleUse && parentObject.isUsed))
        {
            return;
        }
        GetComponent<Collider>().enabled = true;
    }


}
