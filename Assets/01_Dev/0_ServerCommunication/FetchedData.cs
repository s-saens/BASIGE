using socket.io;

public class FetchedData
{

    public static Layout map;
    public static Layout user;
    
    private void Start() {
        InitializeServerSocket();
    }

    private void InitializeServerSocket() {

        string serverUrl = "";
        Socket socket = Socket.Connect(serverUrl);

    }
}

