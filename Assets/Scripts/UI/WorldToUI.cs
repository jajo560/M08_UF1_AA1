using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class WorldToUI : MonoBehaviour
{
    Camera cam;
    RectTransform rectTransform;
    public Transform target;
    void Start()
    {
        cam = Camera.main;
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        Vector3 pos = cam.WorldToViewportPoint(target.position);

        if (pos.z < 0)
        {
            pos.x = 1f - pos.x;
            pos.y = 1f - pos.y;
        }

        float padding = 0.05f;
        pos.x = Mathf.Clamp(pos.x, padding, 1 - padding);
        pos.y = Mathf.Clamp(pos.y, padding, 1 - padding);

        rectTransform.anchorMin = pos;
        rectTransform.anchorMax = pos;
    }
}
