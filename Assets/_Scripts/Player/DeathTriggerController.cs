using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Experimental.GraphView.GraphView;

[RequireComponent(typeof(Collider))]

public class DeathTriggerController : MonoBehaviour
{
    private Animator animator;
 
    
    private bool isDead = false;

    private void Start()
    {
        // animator = GetComponent<Animator>();    
        isDead = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isDead && other.CompareTag("DeathZone"))
        {
            GameManager.GetInstance().EndGame(false);
            isDead = true;
            this.GetComponent<DeathTriggerController>().enabled = false;
            
        }
    }
}