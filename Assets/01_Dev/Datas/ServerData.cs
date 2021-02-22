using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ServerData { // Server의 GameLayout 클래스

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

        // bugs : Dictionary 객체 생성
        bugs = new Dictionary<string, Bug>();
    }

    public static void UpdateData(Block[][] bl, Dictionary<string, Bug> b, Cat c) {
        blocks = bl;
        bugs = b;
        cat = c;
    }

    public static void InitializeDummies() {
        
        InitializeDataObjects();

        // 

        for(int y=0 ; y<mapSize ; ++y) {
            for(int x=0 ; x<mapSize ; ++x) {

                blocks[y][x] = new Block(null, null);

            }
        }

        // bugs
        int bugsCount = 30;

        for(int i=0 ; i<bugsCount ; ++i) {

            Bug bug = new Bug(i.ToString(), i.ToString(), new Position(i, i));
            bugs.Add(bug.id, bug);

        }

        // cat
        cat = new Cat("sksmswhsskrhdiddlek", "nyang", new Position(12, 12));
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
    
    public Cat(string idSet, string nicknameSet, Position posSet) {
        
        id = idSet;
        nickname = nicknameSet;

        size = 4;

        position = posSet;

        velocity = 1;
        score = 0;
        color = 0;
        isAlive = true;

    }

}

public class Bug : User {

    public Bug(string idSet, string nicknameSet, Position posSet) {
        id = idSet;
        nickname = nicknameSet;

        size = 1;

        position = posSet;

        velocity = 1;
        score = 0;
        color = 0;
        isAlive = true;

    }
}