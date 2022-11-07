using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class NetworkPlayer : NetworkBehaviour, IPlayerLeft
{
    public static NetworkPlayer Local { get; set; }

    public Transform playerModel;

    public GameObject emojis;

    public override void Spawned()
    {
        base.Spawned();

        if (Object.HasInputAuthority)
        {
            Local = this;
            
            //set layer del player local
            Utils.SetRenderLayerInChildren(playerModel, LayerMask.NameToLayer("LocalPlayerModel"));

            //desactivar main cam
            Camera.main.gameObject.SetActive(false);

            Debug.Log("SpawnedLocal");
        }
        else
        {
            //desactivar emojis de otros;
            EmojiHandler emojis = GetComponentInChildren<EmojiHandler>();
            emojis.enabled = false;

            //desactivar camara de otros
            Camera localCamera = GetComponentInChildren<Camera>();
            localCamera.enabled = false;

            //desactivar audio de otros;
            AudioListener audioListener = GetComponentInChildren<AudioListener>();
            audioListener.enabled = false;

            Debug.Log("SpawnedRemote");         
        }
    }

    public void PlayerLeft(PlayerRef player)
    {
        if (player == Object.InputAuthority)
            Runner.Despawn(Object);
    }
}


