using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Progressor : MonoBehaviour, Interactable
{
    // Start is called before the first frame update
    public string message;
    public PlayerInventory playerInventory;
    void Start()
    {

        Debug.Log("Start running in Progressor.cs!");

        // if (player != null)
        // {
        //     Debug.Log("Player Inventory Found");
        // } else
        // {
        //     Debug.Log("No player inventory found.");
        // }

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
        Debug.Log("Count: " + count);

        if (count == 1)
        {
            message = "You've recalled your first memory";
        } else if (count == 2)
        {
            message = "Your memories are becoming clearer";
        } else if (count == 3)
        {
            message = "You remember the truth.";
        } else
        {
            message = "You currently have no memories.";
        }
    }

    public void Interact()
    {
        Debug.Log(message);
        UIManager.Instance.ShowInteractionText(message, 3f);
    }
}
