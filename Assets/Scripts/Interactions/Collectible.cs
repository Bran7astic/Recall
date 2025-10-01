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
        Debug.Log(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
