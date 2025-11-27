using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WildBall.Inputs;

public class ButtonTriggerController : MonoBehaviour
{
    private bool isPressed = false;
    [SerializeField] bool canBePressed = true;
    [SerializeField] bool isSingleUse = false;


    Animator buttonAnimator;
    AudioSource buttonAudioSource;

    [SerializeField] AudioClip buttonPressSound;
    [SerializeField] AudioClip buttonReleaseSound;

    TriggerController thisTriggerController;

    private void Start()
    {
        buttonAnimator = GetComponent<Animator>();
        buttonAudioSource = GetComponent<AudioSource>();

        thisTriggerController = GetComponent<TriggerController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && canBePressed)
        {
            PressButton();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (!isSingleUse)
            {
                ReleaseButton();
            }
            else
            {
                canBePressed = false;
            }
        }
    }

    private void PressButton()
    {
        buttonAnimator.SetTrigger("ActivateButtonTrigger");
        thisTriggerController.UseTrigger();
    }

    private void ReleaseButton()
    {
        buttonAnimator.SetTrigger("ReleaseButtonTrigger");
        thisTriggerController.UseTrigger();
    }

    private void PlayButtonSound()
    {
        buttonAudioSource.clip = isPressed ? buttonReleaseSound : buttonPressSound;
        buttonAudioSource.Play();
    }

    private void ButtonChangeState()
    {
        isPressed = !isPressed;
        buttonAnimator.SetBool("isUsed", isPressed);
    }

    private void UnlockButton()
    {
        canBePressed = true;
    }

    private void LockButton()
    {
        canBePressed = false;
    }

}
