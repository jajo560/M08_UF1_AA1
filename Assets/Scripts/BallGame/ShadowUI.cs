using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowUI : MonoBehaviour
{
    public Camera cam;

    public GameObject player;
    public GameObject shadowUI;
    public GameObject targetUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BallShadow();

    }
    public void BallShadow()
    {
        bool occluded = false;
        RaycastHit hit;
        Vector3 direction = (player.transform.position - cam.transform.position).normalized;
        Ray ray = new Ray(cam.transform.position, direction);
        Debug.DrawLine(cam.transform.position, player.transform.position, Color.yellow);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider.tag != "Player")
            {
                occluded = true;
            }
        }

        Vector3 viewportPos = cam.WorldToViewportPoint(player.transform.position);

        if (viewportPos.z < 0)
        {
            viewportPos.x = 1f - viewportPos.x;
            viewportPos.y = 1f - viewportPos.y;
        }

        float padding = 0.05f;
        viewportPos.x = Mathf.Clamp(viewportPos.x, padding, 1 - padding);
        viewportPos.y = Mathf.Clamp(viewportPos.y, padding, 1 - padding);

        shadowUI.SetActive(occluded);

        if (occluded)
        {
            RectTransform rt = shadowUI.GetComponent<RectTransform>();
            rt.anchorMin = new Vector2(viewportPos.x, viewportPos.y);
            rt.anchorMax = new Vector2(viewportPos.x, viewportPos.y);
        }
    }

}
