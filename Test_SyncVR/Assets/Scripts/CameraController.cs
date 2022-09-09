using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform camTransform;
    GameManager gm;
    CrosshairAnim crosshairAnim;
    public LayerMask interactable;
    public bool isControllingDrone;
    public float mouseSensitivity = 100f;
    public float timeToPause;
    float currentTimeToPause;
    float xRotation = 0f;
    float yRotation = 0f;
    bool lookingForPause;
    private void Start()
    {
        camTransform = GetComponent<Transform>();
        currentTimeToPause = timeToPause;
        gm = FindObjectOfType<GameManager>();
        crosshairAnim = FindObjectOfType<CrosshairAnim>();
    }
    void Update()
    {
        Move();
        CheckForPause();
        if (!isControllingDrone)
            ThrowRaycast();
    }
    private void Move()
    {
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        yRotation += mouseX;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        camTransform.Rotate(Vector3.up * mouseX);
    }

    void CheckForPause()
    {
        if (xRotation >= 85f || xRotation <= -85f)
            lookingForPause = true;
        else
            lookingForPause = false;

        if (lookingForPause)
            currentTimeToPause -= Time.deltaTime;
        else
            currentTimeToPause = timeToPause;

        if(currentTimeToPause <= 0)
        {
            gm.PauseGame();
            lookingForPause = false;
            currentTimeToPause = timeToPause;
        }
    }
    void ThrowRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, interactable))
        {
            if (hit.transform.GetComponent<Button>())
            {
                crosshairAnim.StartAnim(hit.transform.GetComponent<Button>());
            }
            else if (hit.transform.GetComponent<DroneController>())
            {
                crosshairAnim.StartAnim(hit.transform.GetComponent<DroneController>());
            }
        }
        else
            crosshairAnim.StopAnim();

        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 100.0f, Color.green);

    }
}
