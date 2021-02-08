using UnityEngine;
using System.Collections.Generic;

public class ServerData { // Server의 GameLayout 클래스
   
    public static Block[][] blocks;
    public static Dictionary<string, User> users;

    private void addListener() {
        ServerHandler.socket.On("update-block", (data) => {
            JsonUtility.FromJson<Block>(data);
        });
        ServerHandler.socket.On("update-user", (data) => {
            JsonUtility.FromJson<User>(data);
        });
    }
}

public class Block {

    public string id;
    public bool isFixed;
    public bool isOwnerStand;
}

public class User {

    private int x;
    private int y;
    public string id;
    public int color;
    public int velocity;
    public char direction;
    public int score;
    
    public Vector3 getPosition() {
        return new Vector3(this.x, 0, this.y);
    }

    public Quaternion getRotation() {
        switch(direction) {
            case 'w' : return Quaternion.Euler(0,0,0);
            case 'a' : return Quaternion.Euler(0,90,0);
            case 's' : return Quaternion.Euler(0,180,0);
            case 'd' : return Quaternion.Euler(0,270,0);
            default : return Quaternion.Euler(0,0,0);
        }
    }
}