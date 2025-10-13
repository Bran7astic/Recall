using System;
using UnityEngine;
using UnityEngine.InputSystem;  // New Input System

public class AddToInventory : MonoBehaviour
{
    [SerializeField] private Camera cam;  // Assign in Inspector; falls back to Camera.main
    private PlayerInventory playerInventory;

    private void Start() {
        playerInventory = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();
        if (playerInventory == null) {
            Debug.LogError("No inventory found");
        }
    }

    private void Awake()
    {
        if (cam == null) cam = Camera.main;
    }

    private void Update()
    {
        // E key
        if (Input.GetKeyDown(KeyCode.E)) {
            TryDeleteAtScreenPos(Mouse.current.position.ReadValue());
        }
    }


    private void TryDeleteAtScreenPos(Vector2 screenPos)
    {
        if (cam == null) return;

        Ray ray = cam.ScreenPointToRay(screenPos);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {

            Interactable interactable = hit.collider.gameObject.GetComponent<Interactable>() ??
                                        hit.collider.gameObject.GetComponentInParent<Interactable>();
            // Debug.Log("Interactable?: " + interactable);

            if (interactable != null)
            {
                interactable.Interact();
            }
            else
            {
                Debug.Log($"Hit {hit.collider.name}, but it's not interactable");
            }
        }
    }
}
