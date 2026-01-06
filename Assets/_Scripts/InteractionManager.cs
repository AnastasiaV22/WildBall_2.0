using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WildBall.Inputs;
using static UnityEditor.Progress;

public class InteractionManager : MonoBehaviour
{
    InputController inputController;
    UIController uiController;

    [SerializeField] private Transform playerTransform;

    private List<InteractableObject> interactableObjectsInRange = new List<InteractableObject>();
    private InteractableObject targetObject;



    void Awake()
    {
        inputController = FindObjectOfType<InputController>();
        uiController = FindObjectOfType<UIController>();


        if (inputController != null)
        {
            Debug.Log("InputController found");
        }
        if (uiController != null)
        {
            Debug.Log("uiController found");
        }
    }

    void FixedUpdate()
    {
        UpdateInteractionTarget();
    }

    public void AddNewInteractableObject(InteractableObject interactableObject)
    {
        if (interactableObject != null)
        {
            interactableObjectsInRange.Add(interactableObject);
        }
       
    }

    public void RemoveInteractableObject(InteractableObject interactableObject)
    {
        if (interactableObject != null)
        {
            interactableObjectsInRange.Remove(interactableObject);
            if (interactableObject == targetObject)
            {
                RemoveLinks(targetObject);
                targetObject = null;
                OnTargetChanged();
                UpdateInteractionTarget();
            }
        }
    }

    private void UpdateInteractionTarget()
    {
        if (interactableObjectsInRange.Count == 0)
        {
            return;
        }

        float distance = Mathf.Infinity;
        if (targetObject != null)
        {
            distance = Vector3.Distance(targetObject.transform.position, playerTransform.position);
        }

        foreach (InteractableObject item in interactableObjectsInRange)
        {
            if (targetObject == item) continue;

            float currentDistance = Vector3.Distance(item.transform.position, playerTransform.position);
            if (currentDistance < distance)
            {
                distance = currentDistance;

                RemoveLinks(targetObject);
                targetObject = item;
                OnTargetChanged();
            }
        }


    }
    private void RemoveLinks(InteractableObject objectToRelease)
    {
        if (objectToRelease != null)
        {
            inputController.InteractionActivated.RemoveListener(objectToRelease.StartInteraction);
        }
    }

    private void OnTargetChanged()
    {
        if (targetObject != null)
        {
            if (!targetObject.activateByTrigger)
                inputController.InteractionActivated.AddListener(targetObject.StartInteraction);
            uiController?.UpdateMessageText(targetObject.objectType, targetObject.canBeUsed && !targetObject.activateByTrigger);
        }
        else
        {
            uiController.CloseDialogWindow();
        }
    }

    private GameObject FindObjectToInteract()
    {
        float interactionDistance = 2f;

        GameObject newTargetObject = null;
        Collider[] objects = Physics.OverlapSphere(transform.position, interactionDistance, LayerMask.NameToLayer("Interactable"));

        if (objects.Length == 0 )
        {
            return newTargetObject;
        }

        float distance = Mathf.Infinity;

        foreach (Collider item in objects)
        {
            if (Vector3.Distance(transform.position, item.transform.position) < distance)
            {
                newTargetObject = item.gameObject;
                distance = Vector3.Distance(transform.position, item.transform.position);
            }
        }

        return newTargetObject;
    }
}
