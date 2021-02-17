using UnityEngine;
using socket.io;
using ;
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
        

        socket.On(SystemEvents.connect, () => {
            Debug.Log("Connected successfully");
            socket.Emit("test", "name: 'testA'");
        });

        // Server 
        socket.On("test", (string data) => {
            socket.Emit("test_for_client", "asdas : asdasd");
        });


        socket.On("test_for_client", (string data) => {
            Debug.Log(data.);
        });
    }

    private void ServerDataFetch() {
        
    }

    private void AddRefreshListener() {
        socket.On("refresh", (E) => {
            string id = E.data["id"].ToString().RemoveQuotes();

        });
    }

    private void AddSkillListener() {

    }

    
}