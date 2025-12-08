using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Progressor : MonoBehaviour, Interactable
{
    // Start is called before the first frame update
    public string message;
    private PlayerInventory playerInventory;
    void Start()
    {
        message = "You don't have any memories";
        GameObject player = GameObject.FindWithTag("Player");
        playerInventory = player.GetComponent<PlayerInventory>();

        playerInventory.OnInventoryChanged += UpdateMessage;
        UpdateMessage();
    }

    void OnDestroy()
    {
        playerInventory.OnInventoryChanged -= UpdateMessage;
    }
    // Update is called once per frame
    void UpdateMessage()
    {
        int count = playerInventory.GetCount();

        if (count == 1)
        {
            message = "You've recalled your first memory";
        } else if (count == 2)
        {
            message = "Your memories are becoming clearer";
        } else if (count == 3)
        {
            message = "You remember the truth.";
        }
    }

    public void Interact()
    {
        Debug.Log(message);
        UIManager.Instance.ShowInteractionText(message, 3f);
    }
}
