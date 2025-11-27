using UnityEngine;
using WildBall.Inputs;

public class InteractionZoneController : MonoBehaviour
{
    InputController inputController;
    UIController uiController;

    [SerializeField] InteractableObject parentObject;

    private void Awake()
    {
        inputController = FindObjectOfType<InputController>();
        uiController = FindObjectOfType<UIController>();

        if (inputController != null )
        {
            Debug.Log("InputController found");
        }
        if (uiController != null)
        {
            Debug.Log("uiController found");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            inputController.InteractionActivated.AddListener(parentObject.StartInteraction);
            uiController?.ShowHelpMessage(parentObject.objectType, parentObject.canBeUsed);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            inputController.InteractionActivated.RemoveListener(parentObject.StartInteraction);
        }

    }

    public void DestroyInteractionArea()
    {
        //close dialog windows
    }
    /*
    private void Interaction()
    {
        inputController.InteractionActivated.AddListener(parentObject.StartInteraction);
        uiController.ShowHelpMessage(parentObject.objectType, parentObject.canBeUsed);
    }

    private void ExitZone()
    {
        inputController.InteractionActivated.RemoveListener(parentObject.StartInteraction);
        uiController.HideHelpMessage();
    }
    */




}
