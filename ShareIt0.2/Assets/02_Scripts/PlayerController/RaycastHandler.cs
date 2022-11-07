using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class RaycastHandler : NetworkBehaviour
{
    public GameManager gameManager;
    public bool isInteracting { get; set; }
    public bool canInteract = false;
    public float InteractDistance;
    public Transform aimPoint;
    public LayerMask interactablesLayer;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    public override void FixedUpdateNetwork()
    {
        if (GetInput(out NetworkInputData networkInputData))
        {
            if (networkInputData.interactable)
                Interact(networkInputData.aimForwardVector);
        }
    }

    void Interact(Vector3 aimForwardVector)
    {
        Runner.LagCompensation.Raycast(aimPoint.position, aimForwardVector, 2, Object.InputAuthority, out var hitInfo, interactablesLayer, HitOptions.IncludePhysX);

        bool isHitInteractable = false;

        if (hitInfo.Distance > 0)
            InteractDistance = hitInfo.Distance;

        if(hitInfo.Hitbox != null)
        {
            Debug.Log($"{Time.time}{transform.name} hit hitbox {hitInfo.Hitbox.transform.root.name }");
        }
        else if(hitInfo.Collider != null)
        {
            Debug.Log($"{Time.time}{transform.name} hit PhysX collider {hitInfo.Hitbox.transform.root.name }");
        }

        if(hitInfo.GameObject.tag == "RedButton")
        {
            gameManager.RedButtonPressed();
            Debug.DrawRay(aimPoint.position, aimForwardVector * InteractDistance, Color.red, 1);
        }

        if (hitInfo.GameObject.tag == "BlueButton")
        {
            gameManager.BlueButtonPressed();
            Debug.DrawRay(aimPoint.position, aimForwardVector * InteractDistance, Color.blue, 1);
        }
        
        if(hitInfo.GameObject.tag == "PurpleButton")
        {
            gameManager.PurpleButtonPressed();
            Debug.DrawRay(aimPoint.position, aimForwardVector * InteractDistance, Color.magenta, 1);
        }

        if(hitInfo.GameObject.tag == "YellowButton")
        {
            gameManager.YellowButtonPressed();
            Debug.DrawRay(aimPoint.position, aimForwardVector * InteractDistance, Color.yellow, 1);
        }

        //Debug
        if (isHitInteractable)
            Debug.DrawRay(aimPoint.position, aimForwardVector * InteractDistance, Color.red, 1);
        else Debug.DrawRay(aimPoint.position, aimForwardVector * InteractDistance, Color.green, 1);
    }

}
