using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class PlayerMovementHandler : NetworkBehaviour
{

    PlayerController playerController;
    Camera localCamera;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        localCamera = GetComponentInChildren<Camera>();
    }


    public override void FixedUpdateNetwork()
    { 
        //Input desde server
        if(GetInput(out NetworkInputData networkInputData))
        {
            //Rotar vista
            transform.forward = networkInputData.aimForwardVector;

            //Cancelar rotacion X para que el player no tiltee
            Quaternion rotation = transform.rotation;
            rotation.eulerAngles = new Vector3(0, rotation.eulerAngles.y, rotation.eulerAngles.z);
            transform.rotation = rotation;
           
            //Move
            Vector3 moveDirection = transform.forward * networkInputData.movementInput.y + transform.right * networkInputData.movementInput.x;
            moveDirection.Normalize();

            playerController.Move(moveDirection);
        }
    }
}
