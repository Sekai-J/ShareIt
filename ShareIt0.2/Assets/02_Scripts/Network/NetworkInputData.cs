using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;

public struct NetworkInputData : INetworkInput
{
    public Vector2 movementInput;
    public Vector3 aimForwardVector;
    public NetworkBool interactable;

}
