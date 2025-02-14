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
        RaycastHit hit;
        Ray ray = new Ray(cam.transform.position, (player.transform.position - cam.transform.position).normalized);
        Debug.DrawLine(cam.transform.position, player.transform.position, Color.yellow);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider.tag == "Player")
            {
                shadowUI.SetActive(false);

                Debug.Log("Player hit");
            }
            else
            {
                shadowUI.SetActive(true);
                Debug.Log("Else hit");
            }
        }
    }

}
