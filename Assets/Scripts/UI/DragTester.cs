using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragTester : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public RectTransform circleSpace;
    public RectTransform innerCircle;

    public static Vector2 inputVector;
    public GameObject joystick;
    private Vector2 originalPosition;

    void Start()
    {
        originalPosition = circleSpace.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        joystick.transform.position = eventData.position;
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        CalculateInnerCirclePosition(eventData.position);
        CalculateInputVector();
        CalculateInnerCircleRotation();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        innerCircle.anchoredPosition = Vector2.zero;
        innerCircle.localRotation = Quaternion.identity;
        inputVector = Vector2.zero;
    }
    private void CalculateInnerCirclePosition(Vector2 position)
    {
        Vector2 direccionPosition = position - (Vector2)circleSpace.position;
        if (direccionPosition.magnitude > circleSpace.rect.width / 2f)
            direccionPosition = direccionPosition.normalized * circleSpace.rect.width / 2f;

        innerCircle.anchoredPosition = direccionPosition;
    }

    private void CalculateInnerCircleRotation()
    {
        innerCircle.localRotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.up, inputVector));
    }

    private void CalculateInputVector()
    {
        inputVector = innerCircle.anchoredPosition / (circleSpace.rect.size / 2f);
    }

  

}
