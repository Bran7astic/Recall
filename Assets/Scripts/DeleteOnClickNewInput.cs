using UnityEngine;
using UnityEngine.InputSystem;  // New Input System

public class DeleteOnClickNewInput : MonoBehaviour
{
    [SerializeField] private Camera cam;  // Assign in Inspector; falls back to Camera.main

    private void Awake()
    {
        if (cam == null) cam = Camera.main;
    }

    private void Update()
    {
        // Mouse click
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            TryDeleteAtScreenPos(Mouse.current.position.ReadValue());
        }

        // Touch tap (first touch)
        if (Touchscreen.current != null)
        {
            var touch = Touchscreen.current.primaryTouch;
            if (touch.press.wasPressedThisFrame)
            {
                TryDeleteAtScreenPos(touch.position.ReadValue());
            }
        }
    }

    private void TryDeleteAtScreenPos(Vector2 screenPos)
    {
        if (cam == null) return;

        Ray ray = cam.ScreenPointToRay(screenPos);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.CompareTag("Collectible")) // Check if item is Collectible
                Destroy (hit.collider.gameObject);
        }
    }
}
