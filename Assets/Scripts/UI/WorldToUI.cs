using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class WorldToUI : MonoBehaviour
{
    Camera cam;
    RectTransform rectTransform;
    public Transform target;
    public Image image;


    void Start()
    {
        cam = Camera.main;
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }

    void Update()
    {
        TargetShadow();
    }

    public void TargetShadow()
    {
        Vector3 pos = cam.WorldToViewportPoint(target.position);

        bool onScreen = (pos.z > 0 && pos.x >= 0 && pos.x <= 1 && pos.y >= 0 && pos.y <= 1);

        float alpha = 1f;

        if (onScreen)
        {
            alpha = 0.5f;

            Ray ray = new Ray(cam.transform.position, (target.position - cam.transform.position).normalized);
            RaycastHit hit;
            Debug.DrawLine(cam.transform.position, target.transform.position, Color.green);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.tag == "Target")
                {
                    alpha = 0.25f;
                }
            }
        }

        if (pos.z < 0)
        {
            pos.x = 1f - pos.x;
            pos.y = 1f - pos.y;
        }

        float padding = 0.05f;
        pos.x = Mathf.Clamp(pos.x, padding, 1 - padding);
        pos.y = Mathf.Clamp(pos.y, padding, 1 - padding);

        rectTransform.anchorMin = new Vector2(pos.x, pos.y);
        rectTransform.anchorMax = new Vector2(pos.x, pos.y);

        Color currentColor = image.color;
        currentColor.a = alpha;
        image.color = currentColor;
    }


}
