using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUI : MonoBehaviour
{
    public BallController ballController;
    public CameraController cameraController;
    public DragTester dragTester;

    public GameObject anythingPanel;
    public GameObject settingsPanel;
    public GameObject biggerPanel;
    public GameObject joystick;

    public GameObject viewBall;
    public GameObject viewTarget;
    public GameObject viewMiddlePoint;
    
    // Menu lateral
    public RectTransform menuPanel;
    public float slideDuration = 0.5f;
    public Vector2 hiddenPosition;
    public Vector2 shownPosition;
    private bool isShown = false;
    private Coroutine slideCoroutine;


    private void Start()
    {
        viewTarget.SetActive(true);
        viewMiddlePoint.SetActive(false);
        viewBall.SetActive(false);
        settingsPanel.SetActive(true);
        anythingPanel.SetActive(false);
        biggerPanel.SetActive(false);
    }

    public void JumpButton()
    {
        ballController.Jump();
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

    public bool IsStatic()
    {
        if (dragTester.isStatic == false)
        {
            dragTester.isStatic = true;
        }
        if (dragTester.isStatic == true)
        {
            dragTester.isStatic = false;
        }
        return dragTester.isStatic;
    }

    public void ToggleMenu()
    {
        if (slideCoroutine != null)
            StopCoroutine(slideCoroutine);

        Vector2 target;
        if (isShown)
        {
            joystick.SetActive(true);
            target = hiddenPosition;
            biggerPanel.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            joystick.SetActive(false);
            biggerPanel.SetActive(true);
            target = shownPosition;
        }

        slideCoroutine = StartCoroutine(SlideTo(menuPanel, target, slideDuration));
        isShown = !isShown;
    }

    IEnumerator SlideTo(RectTransform panel, Vector2 targetPos, float duration)
    {
        Vector2 startPos = panel.anchoredPosition;
        float elapsed = 0f;
        while (elapsed < duration)
        {
            panel.anchoredPosition = Vector2.Lerp(startPos, targetPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        panel.anchoredPosition = targetPos;
        if (isShown)
        Time.timeScale = 0f;
    }

    public void ShowSettings()
    {
        settingsPanel.SetActive(true);
        anythingPanel.SetActive(false);
    }

    public void ShowAnything()
    {
        anythingPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }



}
