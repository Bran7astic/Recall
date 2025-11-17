using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Trigger : MonoBehaviour
{

    public string targetTag = "RockCollider";

    private bool triggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (!triggered && other.CompareTag(targetTag))
        {
            triggered = true;

            TriggerEvent();
        }
    }

    void TriggerEvent()
    {
        Debug.Log("Rock is in place");
    }

}
