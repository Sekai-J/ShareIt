using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    Vector2 moveInputVector = Vector2.zero;
    Vector2 viewInputVector = Vector2.zero;

    LocalCameraHandler localCameraHandler;
    PlayerMovementHandler playerMovementHandler;

    public bool isInteracting = false;

    private void Awake()
    {
        localCameraHandler = GetComponentInChildren<LocalCameraHandler>();
        playerMovementHandler = GetComponent<PlayerMovementHandler>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (!playerMovementHandler.Object.HasInputAuthority)
            return;

        viewInputVector.x = Input.GetAxis("Mouse X");
        viewInputVector.y = Input.GetAxis("Mouse Y") * -1; 

        moveInputVector.x = Input.GetAxis("Horizontal");        
        moveInputVector.y = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.F))
            isInteracting = true;


        localCameraHandler.SetViewInputVector(viewInputVector);
    }

    //Input a server
    public NetworkInputData GetNetworkInput()
    {
        NetworkInputData networkInputData = new NetworkInputData();

        //Aim data
        networkInputData.aimForwardVector = localCameraHandler.transform.forward;

        //Move data
        networkInputData.movementInput = moveInputVector;

        //Interact data
        networkInputData.interactable = isInteracting;

        //Reset
        isInteracting = false;

        return networkInputData;
    }
}
