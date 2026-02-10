using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] ParticleSystem explosion;
    [SerializeField] Animator animator;

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("Триггер");
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("Взята");
            DestroyObject();
            //animator.Play();
        }
    }

    private void DestroyObject()
    {
        explosion.Play();
        Destroy(gameObject, 0.5f);

        Debug.Log("Уничтожена");
    }
}
