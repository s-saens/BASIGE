using socket.io;
using UnityEngine;
using System;

public class ServerInitializer : MonoBehaviour
{
    
    private string serverURL = "http://203.254.143.190:3000";

    public void Awake() {

        if(ServerData.socket != null) {

            Destroy(ServerData.socket.gameObject);
        }
        
        ServerData.socket = Socket.Connect(serverURL);
        
        InGameData.Initialize();
        ServerData.InitializeDataObjects();

    }
    
}