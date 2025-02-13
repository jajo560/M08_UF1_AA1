using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera cam;
    public GameObject player;
    public GameObject shadowUI;
    public GameObject targetUI;
    public float margen = 50f;


    public BallGameManager gameManager;

    public float distanceSpeed;
    public Vector2 distanceLimits;
    float desiredDistance;
    public enum Target { Ball, Target, Middlepoint}
    public float centerSpeed;
    public Target target;
    Vector3 desiredCenter;
    public float rotationSpeed;
    Vector3 initialRotation;
    float desiredRotation;
    private void Start()
    {
        cam = Camera.main;
        Zoom(10);
        initialRotation = transform.localEulerAngles;
       
    }
    public void Zoom(float value)
    {
        desiredDistance = Mathf.Clamp(desiredDistance + value, distanceLimits.x, distanceLimits.y);
    }
    public void Rotate(float value)
    {
        desiredRotation += value;
    }
    public void SwitchTargetBall()
    {
        this.target = Target.Ball;
    }
    public void SwitchTargetTarget()
    {
        this.target = Target.Target;
    }
    public void SwitchTargetMiddlepoint()
    {
        this.target = Target.Middlepoint;
    }
    public void SwitchTarget(Target target)
    {
        this.target = target;
    }

    private void Update()
    {
        BallShadow();

        Vector3 screenPos = Camera.main.WorldToScreenPoint(gameManager.currentTarget.transform.position);

        if (screenPos.z < 0)
        {
            screenPos.x = Screen.width - screenPos.x;
            screenPos.y = Screen.height - screenPos.y;
        }

        // Verificar si el objeto está fuera de la vista
        bool fueraDeVista = screenPos.x < margen || screenPos.x > Screen.width - margen ||
                            screenPos.y < margen || screenPos.y > Screen.height - margen;

        // Activar o desactivar el icono
        targetUI.gameObject.SetActive(fueraDeVista);

        if (fueraDeVista)
        {
            // Limitar la posición del indicador para que se mantenga dentro de la pantalla
            float posX = Mathf.Clamp(screenPos.x, margen, Screen.width - margen);
            float posY = Mathf.Clamp(screenPos.y, margen, Screen.height - margen);
            targetUI.transform.position = new Vector3(posX, posY, 0);
        }
    }
    void LateUpdate()
    {
        switch (target)
        {
            case Target.Target:
                desiredCenter = BallGameManager.instance.currentTarget.position;
                break;
            case Target.Middlepoint:
                desiredCenter = (BallGameManager.instance.currentTarget.position + BallGameManager.instance.ball.transform.position) * 0.5f;
                break;
            default:
                desiredCenter = BallGameManager.instance.ball.transform.position;
                break;
        }
        cam.transform.localPosition = Vector3.Lerp(cam.transform.localPosition, new Vector3(0,0,-desiredDistance), distanceSpeed * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, desiredCenter, centerSpeed * Time.deltaTime);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(initialRotation.x, desiredRotation, initialRotation.z), rotationSpeed * Time.deltaTime);
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
