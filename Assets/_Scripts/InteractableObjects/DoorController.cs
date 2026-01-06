using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class DoorController : InteractableObject
{
    // ¬»«”¿À‹ÕŒ≈ œŒ¬≈ƒ≈Õ»≈
    [SerializeField] Animator doorAnimator;

    [SerializeField] AudioClip DoorOpenSound;
    [SerializeField] AudioClip DoorCloseSound;


    // —Œ—“ŒﬂÕ»≈ Ó·˙ÂÍÚ‡
    private bool doorIsOpen = false;

    private void Awake()
    {
        objectType = TypeOfInteractableObject.Door;
    }

    public override void StartInteraction()
    {
        if (inUse)
        {
            // 
        }
        else
        {
            if (canBeUsed)// || (!inUse&activateByTrigger))
            {
                ChangeDoorState();
            }
            else
            {
                Debug.Log("door cant be used");
            }
        }

    }

    public override void EndInteraction()
    {

    }


    private void ChangeDoorState()
    {
        canBeUsed = false;
        StartUsing();
        doorAnimator.SetTrigger("ChangeStateTrigger");
    }

    void PlaySound()
    {
        audioSource.clip = doorIsOpen ? DoorCloseSound : DoorOpenSound;
        audioSource.Play();
    }

    void onAnimationEnd()
    {
        doorIsOpen = !doorIsOpen;
        if (!activateByTrigger)
        {
            canBeUsed = isSingleUse ? false : true;
        }
        EndUsing();
    }
}
