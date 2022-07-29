using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;


public class NManager : NetworkManager
{
    public static event Action ClientOnConnected;
    public static event Action ClientOnDisconnected;
    public static bool isGameInProgress = false;

    public List<NPlayer> Players { get; } = new List<NPlayer>();

    #region  Server
    public override void OnServerConnect(NetworkConnectionToClient conn)
    {
        if (!isGameInProgress) { return; }

        conn.Disconnect();
    }

    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        NPlayer player = conn.identity.GetComponent<NPlayer>();

        Players.Remove(player);

        base.OnServerDisconnect(conn);
    }
    public override void OnStopServer()
    {
        Players.Clear();

        isGameInProgress = false;
    }

    public void StartGame()
    {
        //if (Players.Count < 2) { return; }

        isGameInProgress = true;
        

        ServerChangeScene("Online");

        
    }
    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);
        NPlayer player = conn.identity.GetComponent<NPlayer>();

        Players.Add(player);
        
        player.SetDisplayName($"Player {Players.Count}");

        player.SetPartyOwner(Players.Count == 1);

    }
    public override void OnServerSceneChanged(string sceneName)
    {
     

    }


    #endregion


    #region Client
 
    public override void OnClientConnect()
    {

        base.OnClientConnect();

        ClientOnConnected?.Invoke();
        
    }

    public override void OnClientDisconnect()
    {
        base.OnClientDisconnect();

        ClientOnDisconnected?.Invoke();
    }
    public override void OnStopClient()
    {
        Players.Clear();
    }

    #endregion




}
