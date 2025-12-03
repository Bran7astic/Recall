using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;  // New Input System

public class AddToInventory : MonoBehaviour
{
    [SerializeField] private Camera cam;  // Assign in Inspector; falls back to Camera.main
    public UIDocument controlsUI;
    private PlayerInventory playerInventory;
    private VisualElement interactContainer;
    

    private void Start() {
        playerInventory = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();
        if (playerInventory == null) {
            Debug.LogError("No inventory found");
        }

        
        var interactDoc = controlsUI.rootVisualElement;
        interactContainer = interactDoc.Q<VisualElement>("InteractContainer");
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

        Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if ((hit.collider.gameObject.GetComponent<Interactable>() ??
                hit.collider.gameObject.GetComponentInParent<Interactable>()) 
                != null)
            {
                interactContainer.style.display = DisplayStyle.Flex;
            } else
            {
                interactContainer.style.display = DisplayStyle.None;
            }
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
