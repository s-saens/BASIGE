using System.Collections.Generic;
using UnityEngine;

public class InGameData {
    
    // 3D Objects
    public static GameObject[][] blockObjects;
    public static Dictionary<string, GameObject> userObjects;

    public static void Initialize() {
        
        // block 게임오브젝트 크기 지정
        blockObjects = new GameObject[ServerData.mapSize][];
        for(int i=0 ; i<ServerData.mapSize ; ++i) {
            blockObjects[i] = new GameObject[ServerData.mapSize];
        }
        // bugs 게임오브젝트 Dictionary 객체 생성
        userObjects = new Dictionary<string, GameObject>();

    }

    public static void UpdateBlockObject() {
        for(int y=0 ; y<ServerData.mapSize ; ++y) {
            for(int x=0 ; x<ServerData.mapSize ; ++x) {

                //blockObjects[y][x].GetComponent<MeshRenderer>().material.SetColor();

            }
        }
    }
}
