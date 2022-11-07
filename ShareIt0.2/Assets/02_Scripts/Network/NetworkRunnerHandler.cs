using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fusion;
using Fusion.Sockets;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class NetworkRunnerHandler : MonoBehaviour
{
    public NetworkRunner networkRunnerPrefab;

    private NetworkRunner networkRunner;

    void Start()
    {
        networkRunner = Instantiate(networkRunnerPrefab);
        networkRunner.name = "Network Runner";
    }

    public void HostGame()
    {
        var clientTask = InitializeNetworkRunner (networkRunner, GameMode.Host, NetAddress.Any(), SceneManager.GetActiveScene().buildIndex, null);       

        Debug.Log("HostingServerStarted");               
    }

    public void JoinGame()
    {
        var clientTask = InitializeNetworkRunner (networkRunner, GameMode.Client, NetAddress.Any(), SceneManager.GetActiveScene().buildIndex, null);
        Debug.Log("JoinedServer");        
    }

    public void QuickGame()
    {
        var clientTask = InitializeNetworkRunner(networkRunner, GameMode.AutoHostOrClient, NetAddress.Any(), SceneManager.GetActiveScene().buildIndex, null);        
    }

    protected virtual Task InitializeNetworkRunner(NetworkRunner runner, GameMode gameMode, NetAddress address, SceneRef scene, Action<NetworkRunner> initialized)
    {
        var sceneManager = runner.GetComponents(typeof(MonoBehaviour)).OfType<INetworkSceneManager>().FirstOrDefault();

        if(sceneManager == null)
        {
            sceneManager = runner.gameObject.AddComponent<NetworkSceneManagerDefault>();
        }

        runner.ProvideInput = true;
        

        return runner.StartGame(new StartGameArgs
        {
            GameMode = gameMode,
            Address = address,
            Scene = scene,
            SessionName = "MainSession",
            Initialized = initialized,
            SceneManager = sceneManager
        });
    }
}
