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
    void Start()
    {
        controller = GetComponent<CameraController>();
        input = new UIvsGameInput();
        input.Player.Enable();

    }

    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {
        if (input.Player.MouseScroll.ReadValue<float>() > 0) 
        {
           Zoomin();
        }
        if (input.Player.MouseScroll.ReadValue<float>() < 0) 
        {
            Zoomout();
        }
    }

    public void Zoomin()
    {
        thisCamera.orthographicSize++;
    }

    public void Zoomout()
    {
        thisCamera.orthographicSize--;
    }
}
