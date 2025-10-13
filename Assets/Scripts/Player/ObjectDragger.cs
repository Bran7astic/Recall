using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectDragger : MonoBehaviour
{

    public float dragSpeed = 7f;
    public string draggableTag = "Draggable";
    public Camera mainCamera;
    private GameObject selectedObject;
    private bool isDragging = false;
    private Plane dragPlane;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GetComponent<Camera>();
        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMouseHover();
        HandleMouseInput();
        HandleDragMovement();
    }

    void HandleMouseHover()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.CompareTag(draggableTag))
            {
                Debug.Log("hovering");
                Renderer rend = hit.collider.GetComponent<Renderer>();
                if (rend)
                    rend.material.SetColor("_BaseColor", Color.red);
            }
        }
    }

    void HandleMouseInput()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.CompareTag(draggableTag))
                {
                    selectedObject = hit.collider.gameObject;
                    isDragging = true;

                    dragPlane = new Plane(Vector3.up, selectedObject.transform.position);

                    dragPlane.Raycast(ray, out float enter);
                    offset = selectedObject.transform.position - ray.GetPoint(enter);
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            selectedObject = null;
        }
    }

    void HandleDragMovement()
    {
        if (!isDragging || selectedObject == null)
            return;

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        // Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        if (dragPlane.Raycast(ray, out float distance))
        {
            Vector3 targetPoint = ray.GetPoint(distance) + offset;

            float minY = 0.5f;
            float maxY = 3f;
            targetPoint.y = Mathf.Clamp(targetPoint.y, minY, maxY);

            selectedObject.transform.position = Vector3.Lerp(
                selectedObject.transform.position,
                targetPoint,
                Time.deltaTime * dragSpeed
            );
        }
    }

}
