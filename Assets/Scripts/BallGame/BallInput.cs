using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BallController))]
public class BallInput : MonoBehaviour
{
    UIvsGameInput input;
    BallController controller;
    public bool newInputSystem;
    private void Start()
    {
        controller = GetComponent<BallController>();
        input = new UIvsGameInput();
        input.Player.Enable();
        input.UI.Enable();
    }
    void Update()
    {
        if (newInputSystem)
        {
            controller.Move(input.Player.Move.ReadValue<Vector2>());
            if (input.Player.Jump.IsPressed())
            {
                controller.Jump();

            }
            
        }


    }
}
