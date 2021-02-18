using UnityEngine;
using socket.io;

public class ServerHandler : MonoBehaviour
{
    // TODO : Singleton Pattern 적용하기
    
    public static Socket socket;
    private string serverURL = "http://203.254.143.190:3000";

    private void Start() {

        InitializeServerSocket();
        
        // TODO : receive packets

    }

    private void InitializeServerSocket() {

        socket = Socket.Connect(serverURL);
        

        socket.On(SystemEvents.connect, () => {
            Debug.Log("Connected successfully");
            socket.Emit("test", "name: 'testA'");
        });

        // Server 
        socket.On("test", (string data) => {
            socket.Emit("test_for_client", "asdas : asdasd");
        });


        socket.On("test_for_client", (string data) => {
            Debug.Log(data);
        });
    }

    
}