using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalCameraHandler : MonoBehaviour
{
    Camera localCamera;
    public Transform cameraAnchorPoint;

    PlayerController playerController;

    //input
    Vector2 viewInput;

    //rotacion
    float cameraRotationX = 0;
    float cameraRotationY = 0;

    private void Awake()
    {
        localCamera = GetComponent<Camera>();
        playerController = GetComponentInParent<PlayerController>();
    }

    void Start()
    {
        //quita la camara como children
        if (localCamera.enabled)
        {
            localCamera.transform.parent = null;
        }
    }

    void LateUpdate()
    {
        if (cameraAnchorPoint == null)
            return;

        if (!localCamera == enabled)
            return;

        localCamera.transform.position = cameraAnchorPoint.position;

        cameraRotationX += viewInput.y * Time.deltaTime * playerController.viewUpDownRotationSpeed;
        cameraRotationX = Mathf.Clamp(cameraRotationX, -90, 90);

        cameraRotationY += viewInput.x * Time.deltaTime * playerController.rotationSpeed;

        localCamera.transform.rotation = Quaternion.Euler(cameraRotationX, cameraRotationY, 0);
    }

    public void SetViewInputVector(Vector2 viewInput)
    {
        this.viewInput = viewInput;
    }

}
