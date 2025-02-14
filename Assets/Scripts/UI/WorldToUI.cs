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

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = cam.WorldToViewportPoint(target.position);
        
        rectTransform.anchorMin = pos;
        rectTransform.anchorMax = pos;
    }
}
