using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ServerData { // Server의 GameLayout 클래스
   
    public static Block[][] blocks;
    public static Cat cat;
    public static Bug[] bugs;

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

    public Position position;

    public int velocity;
    public int score;
    public int color;
    public bool isAlive;
    
    public Vector3 GetUnityPosition() {
        return new Vector3(this.position.x, 0, 100-this.position.y);
    }
    
}

public class Cat : Creature {

    public Dictionary<string, Skill> skills;
    
}

public class Bug : Creature {

}