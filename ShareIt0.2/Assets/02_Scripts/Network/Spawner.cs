using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;
using System;

public class Spawner : MonoBehaviour, INetworkRunnerCallbacks
{
    public NetworkPlayer playerPrefab;

    public GameObject startMenuCanvas;

    public Vector3 player1Spawn;
    public Vector3 player2Spawn;
    public int numberOfSpawn = 0;

    PlayerInputHandler playerInputHandler;

    void Start()
    {
        startMenuCanvas = GameObject.Find("StartMenuCanvas");

        player1Spawn = new Vector3(6, 1.1f, 0);
        player2Spawn = new Vector3(-6, 1.1f, 0);
    }

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        if (runner.IsServer)
        {
            if (numberOfSpawn == 2)
                return;

            if (numberOfSpawn == 0)
            {
                runner.Spawn(playerPrefab, player1Spawn, Quaternion.identity, player);
                numberOfSpawn++;
                Debug.Log("Spawning host player");
            }
            else
            {
                runner.Spawn(playerPrefab, player2Spawn, Quaternion.identity, player);
                numberOfSpawn++;
                Debug.Log("Spawning player 2");
            }            
        }
    }

    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
        if(playerInputHandler == null && NetworkPlayer.Local != null)
        {
            playerInputHandler = NetworkPlayer.Local.GetComponent<PlayerInputHandler>();
        }

        if(playerInputHandler != null)
        {
            input.Set(playerInputHandler.GetNetworkInput());
        }
    }

    public void OnConnectedToServer(NetworkRunner runner) 
    { 
        Debug.Log("OnConnectedToServer");
    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player) { }

    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input) { }

    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason) { Debug.Log("OnShutdown"); }

    public void OnDisconnectedFromServer(NetworkRunner runner) 
    { 
        Debug.Log("OnDisconnectedFromServer");
        startMenuCanvas.SetActive(true);
    }

    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token) { Debug.Log("OnConnectRequest"); }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason) { Debug.Log("OnConnectFailed"); }

    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message) { }

    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList) { }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data) { }

    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken) { }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data) { }

    public void OnSceneLoadDone(NetworkRunner runner) 
    { 
        startMenuCanvas.SetActive(false); 
    }
    public void OnSceneLoadStart(NetworkRunner runner) { }



}
