using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]

public class DeathTriggerController : MonoBehaviour
{
    private Animator animator;
    
    private void Start()
    {
        // animator = GetComponent<Animator>();    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeathZone"))
        {
            GameManager.GetInstance().EndGame(false);
        }
    }
}