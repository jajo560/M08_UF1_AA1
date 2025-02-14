using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CameraController))]
public class CameraInput : MonoBehaviour
{
    CameraController controller;
    public Camera thisCamera;
    UIvsGameInput input;
    private float mouseScroll;
    CameraController cameraController;
   

    void Start()
    {
        controller = GetComponent<CameraController>();
        input = new UIvsGameInput();
        input.Player.Enable();
        input.Player.MouseScroll.performed += x => mouseScroll = x.ReadValue<float>();
        cameraController = GetComponent<CameraController>();
        
        

    }

    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {
        if (mouseScroll > 0) 
        {
           Zoomin();

        }
        if (mouseScroll < 0) 
        {
            Zoomout();
        }
       
    }

    public void Zoomin()
    {
        cameraController.Zoom(-1f);
    }

    public void Zoomout()
    {
        cameraController.Zoom(1f);
    }
}
