using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.Examples.TMP_ExampleScript_01;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class TriggerZoneController : MonoBehaviour
{
    TriggerController thisTriggerController;

    // —Œ—“ŒﬂÕ»≈ Ó·˙ÂÍÚ‡
    private bool triggerActivated = false;

    private void Awake()
    {
        thisTriggerController = GetComponent<TriggerController>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player") && !triggerActivated)
        {
            thisTriggerController?.UseTrigger();
        }
    }
 
}
