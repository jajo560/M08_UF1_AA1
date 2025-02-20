using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUI : MonoBehaviour
{
    public BallController ballController;
    public CameraController cameraController;

    public GameObject button;
    public GameObject scrollPanel;
    public GameObject backButton;
    public GameObject joystick;

    public GameObject viewBall;
    public GameObject viewTarget;
    public GameObject viewMiddlePoint;

    private void Start()
    {
        viewTarget.SetActive(true);
        viewMiddlePoint.SetActive(false);
        viewBall.SetActive(false);
    }

    public void JumpButton()
    {
        ballController.Jump();
    }

    public void ScrollPanel()
    {
        Time.timeScale = 0f;
        joystick.SetActive(false);
        button.SetActive(true);
        scrollPanel.SetActive(false);
        backButton.SetActive(true);

    }
    public void ScrollPanelActive()
    {
        joystick.SetActive(true);
        button.SetActive(false);
        scrollPanel.SetActive(true);
        backButton.SetActive(false);
        Time.timeScale = 1f;

    }
    public void ChangeViewModeTarget()
    {

        cameraController.SwitchTargetTarget();
        viewTarget.SetActive(false);
        viewMiddlePoint.SetActive(true);
        viewBall.SetActive(false);

    }    
    public void ChangeViewModeBall()
    {

        cameraController.SwitchTargetBall();
        viewBall.SetActive(false);
        viewMiddlePoint.SetActive(false);
        viewTarget.SetActive(true);

    }
    public void ChangeViewModeMiddlePoint()
    {

        cameraController.SwitchTargetMiddlepoint();
        viewBall.SetActive(true);
        viewMiddlePoint.SetActive(false);
        viewTarget.SetActive(false);


    }

}
