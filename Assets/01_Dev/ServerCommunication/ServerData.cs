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

    public UserType userType;

    public string id;
    public string nickname;

    public int size;

    public Vector2 position;

    public int velocity;
    public int score;
    public int color;
    public bool isAlive;
    
    public Vector3 GetUnityPosition() {
        return new Vector3(this.position.x, 0, this.position.y);
    }
}

public class Cat : Creature {

    public Dictionary<string, Skill> skills;
    
}

public class Bug : Creature {

}

public class Position {
    int x;
    int y;
}

// ENUMS //

public enum GameState {
    MATCHING,
    PLAYING,
    RESULT
}

public enum Direction {
    UP,
    DOWN,
    LEFT,
    RIGHT
}

public enum UserType {
    CAT,
    BUG
}