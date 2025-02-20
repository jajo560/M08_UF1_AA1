using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

[RequireComponent(typeof(CameraController))]
public class CameraInput : MonoBehaviour
{
    CameraController controller;
    public Camera thisCamera;
    UIvsGameInput input;
    private float mouseScroll;
    CameraController cameraController;
    public Vector2 mouseDelta;
    public float mouseX;
    public float mouseY;
    public float rotationVelocity;
    public bool overUi = false;

  
    //
    void Start()
    {
        controller = GetComponent<CameraController>();
        input = new UIvsGameInput();
        input.Player.Enable();
        cameraController = GetComponent<CameraController>();
        

        
    }

    
    void Update()
    {
        mouseDelta = input.Player.MouseMovement.ReadValue<Vector2>() * rotationVelocity;


        mouseY = mouseDelta.y;
        mouseX = mouseDelta.x;
        if (mouseScroll > 0) 
        {
           Zoomin();

        }
        if (mouseScroll < 0) 
        {
            Zoomout();
        }
        if (input.Player.LeftClick.IsPressed() && overUi == false)
        {
            if (mouseDelta.x > 0)
            {
                cameraController.Rotate(mouseDelta.x);
            }
            else if (mouseDelta.x < 0)
            {
                cameraController.Rotate(mouseDelta.x);
            }
            if(mouseDelta.y > 0)
            {
                cameraController.Rotate(mouseDelta.y);
            }
            else if(mouseDelta.y < 0)
            {
                cameraController.Rotate(mouseDelta.y);
            }
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

   
    public void OverUi()
    {
        overUi = true;
    }
    public void NotOverUi()
    {
        overUi = false;
    }

}
