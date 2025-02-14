using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUI : MonoBehaviour
{
    public BallController ballController;
    public GameObject button;
    public GameObject scrollPanel;
    public GameObject backButton;
    public void JumpButton()
    {
        ballController.Jump();
    }

    public void ScrollPanel()
    {
        button.SetActive(true);
        scrollPanel.SetActive(false);
        backButton.SetActive(true);
    }
    public void ScrollPanelActive()
    {
        button.SetActive(false);
        scrollPanel.SetActive(true);
        backButton.SetActive(false);

    }

}
