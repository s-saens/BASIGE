using UnityEngine;
using socket.io;
using System.Threading.Tasks;

public class ServerHandler : MonoBehaviour
{
    
    public static Socket socket;
    private string serverURL = "http://203.254.143.190:3000";

    private void Start() {

        InitializeServerSocket();

    }

    private void InitializeServerSocket() {

        socket = Socket.Connect(serverURL);
        
        // 연결이 된 경우 실행
        socket.On(SystemEvents.connect, () => {
            Debug.Log("Connected successfully");
            
            socket.EmitJson("test", "name: 'testA'");
        });

    }
    
}