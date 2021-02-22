using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameData : MonoBehaviour {
    

    // 3D Objects
    public GameObject[][] blockObjects;
    public Dictionary<string, GameObject> bugObjectsDict;
    public GameObject catObject;


    private void Start() {
        
        Initialize();

    }

    private void Initialize() {
        
        // block 게임오브젝트 크기 지정
        blockObjects = new GameObject[ServerData.mapSize][];

        for(int i=0 ; i<ServerData.mapSize ; ++i) {
            blockObjects[i] = new GameObject[ServerData.mapSize];
        }

        // bugs 게임오브젝트 Dictionary 객체 생성
        bugObjectsDict = new Dictionary<string, GameObject>();

    }




}
