using socket.io;
using UnityEngine;

public class ServerInitializer : MonoBehaviour
{
    
    private string serverURL = "http://203.254.143.190:3000";

    public void Awake() {

        InGameData.Initialize();
        ServerData.InitializeDataObjects();
        
        ServerData.socket = Socket.Connect(serverURL);

    }
    
}