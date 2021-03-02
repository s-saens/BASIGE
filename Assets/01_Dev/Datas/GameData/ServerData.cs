using UnityEngine;
using socket.io;
using System.Collections.Generic;

public class ServerData : MonoBehaviour{ // 한 게임의 Server의 GameLayout 클래스

    public static Socket socket = null;

    public static string gameId;
    public static int timer;

    public static Block[][] blocks;
    public static Dictionary<string, User> users;
    public static User myClient;
    public static string catId;

    public static int mapSize = 100;

    public static void InitializeDataObjects() {

        // blocks : mapSize x mapSize 크기의 배열 크기 지정
        blocks = new Block[mapSize][];

        for(int i=0 ; i<mapSize ; ++i) {
            blocks[i] = new Block[mapSize];
        }

        // 유저 객체
        users = new Dictionary<string, User>();
    }
}
