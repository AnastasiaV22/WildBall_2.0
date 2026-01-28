using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            // запуск анимации смерти
            // ожидание конца анимации 
            GameManager.GetInstance().EndGame();
        }
    }
}