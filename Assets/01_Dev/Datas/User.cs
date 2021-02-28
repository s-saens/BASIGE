using UnityEngine;
using System.Collections.Generic;

public class User {

    public UserType type;

    public string id; // 소켓 아이디
    public string nickname;

    public int size;

    public Position position;

    public int velocity;
    public int score;
    public string color;
    public bool isAlive;

    public UserState userState;

    // client only
    public bool isMoving;
    public CoroutineQueue cQueue;
    
    public Color GetColor() {

        Color color; // owner's color
        string ownerColorHex = this.color;
        ColorUtility.TryParseHtmlString(ownerColorHex, out color);

        return color;

    }

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