using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    public HashSet<string> inventory = new HashSet<string>();
    public event Action OnInventoryChanged;

    public void AddItem(string itemName)
    {
        if (inventory.Add(itemName))
        {
            Debug.Log(inventory);
            OnInventoryChanged?.Invoke();
        }
    }
    
    public void RemoveItem(string itemName) {
        if (inventory.Remove(itemName))
        {
            OnInventoryChanged?.Invoke();
        }
    }

    public bool HasItem(string item)
    {
        return inventory.Contains(item);
    }
}
