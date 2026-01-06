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

   
    private void Awake()
    {
        objectType = TypeOfInteractableObject.Lever;

        thisTriggerController = GetComponent<TriggerController>();
        Debug.Log($"TriggerController {thisTriggerController}");
    }

    public override void StartInteraction()
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

    public override void EndInteraction()
    {

    }


    private void ChangeLeverState()
    {
        canBeUsed = false;
        leverAnimator.SetTrigger("ChangeStateTrigger");

        StartCoroutine(WaitForAnimationEndTrigger());
    }
    private IEnumerator WaitForAnimationEndTrigger()
    {
        StartUsing();
        while (leverAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            Debug.Log(leverAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime);
            yield return null;
        }

        EndUsing();
        isUsed = !isUsed;
        canBeUsed = isSingleUse ? false : true;
        thisTriggerController?.UseTrigger();
    }

    void PlaySound()
    {
        audioSource.clip = !isUsed ? LeverDownSound : LeverUpSound;
        audioSource.Play();
    }

}
