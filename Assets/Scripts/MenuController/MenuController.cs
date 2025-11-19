using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject GUI;
    private GameObject titleUI;
    private GameObject mainCamera;
    private GameObject titleCamera;
    private GameObject player;

    void Start()
    {
        titleCamera = GameObject.Find("TitleCamera");
        mainCamera = GameObject.Find("CameraHolder");
        player = GameObject.Find("Player");
        titleUI = GameObject.Find("TitleUI");
        

        GUI.SetActive(false);
        titleUI.SetActive(true);
        player.SetActive(false);
        mainCamera.SetActive(false);
        titleCamera.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            player.SetActive(true);
            titleUI.SetActive(false);
            GUI.SetActive(true);
            mainCamera.SetActive(true);
            titleCamera.SetActive(false);
        }
    }
}
