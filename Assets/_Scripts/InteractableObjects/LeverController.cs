using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : InteractableObject
{
    // ¬»«”¿À‹ÕŒ≈ œŒ¬≈ƒ≈Õ»≈
    [SerializeField] Animator leverAnimator;

    [SerializeField] AudioClip LeverDownSound;
    [SerializeField] AudioClip LeverUpSound;

    TriggerController thisTriggerController;


    // —Œ—“ŒﬂÕ»≈ Ó·˙ÂÍÚ‡
    private bool leverUsed = false;

    private void Awake()
    {
        objectType = TypeOfInteractableObject.Lever;

        thisTriggerController = GetComponent<TriggerController>();
        Debug.Log($"TriggerController {thisTriggerController}");
    }

    public override void StartInteraction()
    {
        if (inUse)
        {
            // 
        }
        else
        {
            if (canBeUsed)
            {
                Debug.Log("Lever used");
                ChangeLeverState();

            }
            else
            {
                Debug.Log("Lever cant be used");
            }
        }
    }

    public override void EndInteraction()
    {

    }


    private void ChangeLeverState()
    {
        canBeUsed = false;

        StartUsing();
        leverAnimator.SetTrigger("ChangeStateTrigger");

        StartCoroutine(WaitForAnimationEndTrigger());
    }
    private IEnumerator WaitForAnimationEndTrigger()
    {
        int animationLenght = Convert.ToInt32(leverAnimator.GetCurrentAnimatorStateInfo(0).length);
        yield return new WaitForSeconds(animationLenght);

        thisTriggerController?.UseTrigger();
        leverUsed = !leverUsed;
        canBeUsed = isSingleUse ? false : true;
        EndUsing();
    }

    void PlaySound()
    {
        audioSource.clip = !leverUsed ? LeverDownSound : LeverUpSound;
        audioSource.Play();
    }

}
