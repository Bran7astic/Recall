using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour, Interactable
{

    void Start()
    {
        
    }

    public void Interact()
    {

        GameObject player = GameObject.FindWithTag("Player");
        PlayerInventory playerInventory = player.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            playerInventory.AddItem(this.gameObject.name);
            Destroy(this.gameObject);
        }
        else
        {
            Debug.LogError("Interacted with something other than the Player");
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
