using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ServerData { // Server의 GameLayout 클래스
   
    public static Block[][] blocks;
<<<<<<< HEAD:Assets/01_Dev/ServerCommunication/ServerData.cs
    public static Cat cat;
    public static Bug[] bugs;

=======
    public static Dictionary<string, User> users;

    private void addListener() {
        ServerHandler.socket.On("update-block", (data) => {
            JsonUtility.FromJson<Block>(data);
        });
        ServerHandler.socket.On("update-user", (data) => {
            JsonUtility.FromJson<User>(data);
        });
    }
>>>>>>> movement-feature:Assets/01_Dev/0_ServerCommunication/ServerData.cs
}



public class Block {

    public string id;
    public bool isFixed;
    public bool isOwnerStand;
}

public class User {

<<<<<<< HEAD:Assets/01_Dev/ServerCommunication/ServerData.cs
    public UserType userType;

=======
    private int x;
    private int y;
>>>>>>> movement-feature:Assets/01_Dev/0_ServerCommunication/ServerData.cs
    public string id;
    public string nickname;

    public int size;

    public Position position;

    public int velocity;
    public int score;
    public int color;
    public bool isAlive;
    
<<<<<<< HEAD:Assets/01_Dev/ServerCommunication/ServerData.cs
    public Vector3 GetUnityPosition() {
        return new Vector3(this.position.x, 0, 100-this.position.y);
    }
    
}

public class Cat : Creature {

    public Dictionary<string, Skill> skills;
    
}

public class Bug : Creature {

=======
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
>>>>>>> movement-feature:Assets/01_Dev/0_ServerCommunication/ServerData.cs
}