using socket.io;
using UnityEngine;
using System;

public class ServerInitializer : MonoBehaviour
{
    
    private string serverURL = "http://203.254.143.190:3000";

    public void Awake() {

        if(ServerData.socket != null) {

            Destroy(ServerData.socket.gameObject);
            ServerData.socket = new GameObject(string.Format("socket.io - {0}", serverURL)).AddComponent<Socket>();
            ServerData.socket.transform.SetParent(SocketManager.Instance.transform, false);
            ServerData.socket.Url = new Uri(serverURL);
            SocketManager.Instance.Connect(ServerData.socket); // 재연결!

            return;
        }
        
        InGameData.Initialize();
        ServerData.InitializeDataObjects();
        ServerData.socket = Socket.Connect(serverURL);

    }
    
}