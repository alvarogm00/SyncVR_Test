using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    Transform cameraTransform;
    CameraController cameraController;
    float distanceFromCamera;
    public float movementSpeed;
    public bool isControllingDrone;

    private void Start()
    {
        cameraTransform = FindObjectOfType<Camera>().transform;
        cameraController = FindObjectOfType<CameraController>();
        distanceFromCamera = Vector3.Distance(transform.position, cameraTransform.position);
    }
    void Update()
    {
        if (isControllingDrone)
        {
            Vector3 resultingPosition = cameraTransform.position + cameraTransform.forward * distanceFromCamera;

            transform.position = Vector3.Lerp(transform.position, resultingPosition, movementSpeed * Time.deltaTime);
        }
    }

    public void ControlDrone()
    {
        isControllingDrone = true;
        if(cameraController != null)
            cameraController.isControllingDrone = true;
    }
}
