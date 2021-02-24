using UnityEngine;
using socket.io;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class ServerData { // 한 게임의 Server의 GameLayout 클래스

    public static Socket socket;

    public static string gameId;
    public static int timer;

    public static Block[][] blocks;
    public static Dictionary<string, Bug> bugs;
    public static Cat cat;

    public static int mapSize = 100;

    public static void InitializeDataObjects() {

        // blocks : mapSize x mapSize 크기의 배열 크기 지정
        blocks = new Block[mapSize][];

        for(int i=0 ; i<mapSize ; ++i) {
            blocks[i] = new Block[mapSize];
        }
        cat=new Cat();
        // bugs : Dictionary 객체 생성
        bugs = new Dictionary<string, Bug>();
    }
}

public class Block {

    public string owner;
    public string[] userList;

    public Block(string ownerID, string[] userList) {
        this.owner = ownerID;
        this.userList = userList;
    }

}

public class User {

    public UserType type;

    public string id;
    public string nickname;

    public int size;

    public Position position;

    public int velocity;
    public int score;
    public string color;
    public bool isAlive;

    public UserState userState;
    
    public Vector3 GetUnityPosition() {
        Vector2 convertedXZ;
        float convertedY;
        convertPositionBySize(this.size, out convertedXZ, out convertedY);
        return new Vector3(convertedXZ.x, convertedY, 100 - convertedXZ.y);
    }

    private void convertPositionBySize(int size, out Vector2 posXZ, out float y) {
        Vector2 pos_int = new Vector2(position.x, position.y);
        Vector2 oneVector = new Vector2(1, 1);
        posXZ = pos_int + oneVector * (size-1)/2;
        y = ((float)size)/2;
    }
    
}

public class Cat : User {

    public Dictionary<string, Skill> skills;
    public Cat() {}
    public Cat(string idSet, string nicknameSet, Position posSet) {
        
        id = idSet;
        nickname = nicknameSet;

        size = 4;

        position = posSet;

        velocity = 1;
        score = 0;
        color = "";
        isAlive = true;

    }

}

public class Bug : User {
    public Bug() {}
    public Bug(string idSet, string nicknameSet, Position posSet) {
        id = idSet;
        nickname = nicknameSet;

        size = 1;

        position = posSet;

        velocity = 1;
        score = 0;
        color = "";
        isAlive = true;

    }
}