using UnityEngine;
using System.Collections.Generic;

public class ServerData { // Server의 GameLayout 클래스
   
    public static Block[][] blocks;
    public static Dictionary<string, Creature> users;

    private void addListener() {
        ServerHandler.socket.On("skill-result", (data) => {
            JsonUtility.FromJson<Block>(data);
        });
        ServerHandler.socket.Emit("update-user","asdas");
        
    }

}

public class Block {

    public string id;
    public bool isFixed;
    public bool isOwnerStand;

}

public class Creature: MonoBehaviour {

    public int x;
    public int y;
    public string id;
    public int color;
    public int velocity;
    public char direction;
    public int score;
    
    public Vector3 GetUnityPosition() {
        return new Vector3(this.x, 0, this.y);
    }

    public Quaternion GetUnityRotation() {
        switch(direction) {
            case 'w' : return Quaternion.Euler(0,0,0);
            case 'a' : return Quaternion.Euler(0,90,0);
            case 's' : return Quaternion.Euler(0,180,0);
            case 'd' : return Quaternion.Euler(0,270,0);
            default : return Quaternion.Euler(0,0,0);
        }
    }
}

public class Cat : Creature {

    public Dictionary<string, Skill> skills;
    
}

public class Bug : Creature {

}