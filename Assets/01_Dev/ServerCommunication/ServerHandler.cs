using UnityEngine;
using socket.io;

public class ServerHandler : MonoBehaviour
{
    // TODO : Singleton Pattern 적용하기
    
    public static Socket socket;
    private string serverURL = "http://localhost:7001";

    private void Start() {

        InitializeServerSocket();

    }

    private void InitializeServerSocket() {

        socket = Socket.Connect(serverURL);

        socket.On("connected", () => {
            Debug.Log("Connected successfully");
        });
    }
}