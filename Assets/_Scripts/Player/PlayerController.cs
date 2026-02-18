using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] GameManager gameManager;

    [SerializeField] Animator animator;
    [SerializeField] ParticleSystem deathEffects;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.PlayerDied.AddListener(OnPlayerDeath);
    }

    private void OnPlayerDeath()
    {
        animator.Play("DeathState");
        deathEffects.Play();
    }
}
