using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelSize : MonoBehaviour
{
    public RectTransform panelRect;
    public Slider slider;
    public float minWidth = 100f;
    public float maxWidth = 500f;

    void Start()
    {
        slider.minValue = minWidth;
        slider.maxValue = maxWidth;
        slider.value = panelRect.sizeDelta.x;
        slider.onValueChanged.AddListener(UpdatePanelWidth);
    }

    void UpdatePanelWidth(float newWidth)
    {
        Vector2 sizeDelta = panelRect.sizeDelta;
        sizeDelta.x = newWidth;
        panelRect.sizeDelta = sizeDelta;
    }
}
