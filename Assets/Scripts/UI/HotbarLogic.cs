using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Processors;
using UnityEngine.UIElements;

public class HotbarLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerInventory playerInventory;
    private VisualElement root;


    void OnEnable()
    {
        var doc = GetComponent<UIDocument>();
        root = doc.rootVisualElement;

        playerInventory.OnInventoryChanged += UpdateHotbarUI;
        UpdateHotbarUI();
    }

    void OnDisable()
    {
        playerInventory.OnInventoryChanged -= UpdateHotbarUI;
    }

    void UpdateHotbarUI()
    {
        var greenMemory = root.Q<VisualElement>("GreenMemory");
        var redMemory = root.Q<VisualElement>("RedMemory");
        var blueMemory = root.Q<VisualElement>("BlueMemory");

        greenMemory.style.display = playerInventory.HasItem("GreenMemory") 
        ? DisplayStyle.Flex
        : DisplayStyle.None;

        redMemory.style.display = playerInventory.HasItem("RedMemory") 
        ? DisplayStyle.Flex
        : DisplayStyle.None;

        blueMemory.style.display = playerInventory.HasItem("BlueMemory") 
        ? DisplayStyle.Flex
        : DisplayStyle.None;

    }
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
