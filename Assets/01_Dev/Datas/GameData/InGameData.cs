using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


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

    public static void UpdateBlocks(Position pos) {
        
        Material mat = blockObjects[pos.y][pos.x].GetComponent<MeshRenderer>().material;
        mat.DOColor(ServerData.blocks[pos.y][pos.x].GetColor(), 0.4f);

    }

}
