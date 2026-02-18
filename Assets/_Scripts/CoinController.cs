using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] ParticleSystem explosion;
    [SerializeField] Animator animator;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            DestroyObject();
            //animator.Play();
        }
    }

    private void DestroyObject()
    {
        animator.SetTrigger("DestroyCoinTrigger");
        explosion.Play();
        Destroy(gameObject, 0.5f);

    }
}
