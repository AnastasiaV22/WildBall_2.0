using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactionDistance = 2f;

    private GameObject targetInteractableObject;




    void Start()
    {
        
    }

    void Update()
    {
        targetInteractableObject = FindObjectToInteract();
    }

    private GameObject FindObjectToInteract()
    {
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
