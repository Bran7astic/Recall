using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuController : MonoBehaviour
{
    public GameObject GUI;
    private GameObject titleUI;
    private GameObject controlsUI;
    private GameObject mainCamera;
    private GameObject titleCamera;
    private GameObject player;
    private VisualElement root;

    void Start()
    {
        titleCamera = GameObject.Find("TitleCamera");
        mainCamera = GameObject.Find("CameraHolder");
        player = GameObject.Find("Player");
        titleUI = GameObject.Find("TitleUI");

        controlsUI = GameObject.Find("ControlsUI");
        var controlsDoc = controlsUI.GetComponent<UIDocument>();
        root = controlsDoc.rootVisualElement;
        
        

        GUI.SetActive(false);
        titleUI.SetActive(true);
        controlsUI.SetActive(true);
        player.SetActive(false);
        mainCamera.SetActive(false);
        titleCamera.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            player.SetActive(true);
            titleUI.SetActive(false);
            // hide controls container in controls UI
            var controlsContainer = root.Q<VisualElement>("ControlsContainer");
            controlsContainer.style.display = DisplayStyle.None;
            GUI.SetActive(true);
            mainCamera.SetActive(true);
            titleCamera.SetActive(false);
        }
    }
}
