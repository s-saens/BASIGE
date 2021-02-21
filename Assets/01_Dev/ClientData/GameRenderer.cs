using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameRenderer : MonoBehaviour {

    // must be assigned in the inspector
    public GameObject blockPrefab;
    public GameObject bugPrefab;
    public GameObject catPrefab;

    public Transform parent_blocks;
    public Transform parent_bug;
    public Transform parent_cat;

    private GameObject[][] blockObjects;
    [HideInInspector]
    public Dictionary<string, GameObject> bugObjectsDict; // id, Bug 쌍
    [HideInInspector]
    public GameObject catObject;

    public void Initialize() {

        // block 게임오브젝트 크기 지정
        blockObjects = new GameObject[ServerData.mapSize][];

        for(int i=0 ; i<ServerData.mapSize ; ++i) {
            blockObjects[i] = new GameObject[ServerData.mapSize];
        }

        // bugs 게임오브젝트 Dictionary 객체 생성
        bugObjectsDict = new Dictionary<string, GameObject>();

    }

    public void Render() {
    
        Initialize();
        ServerData.InitializeDummies();
        RenderBlocks();
        RenderCat();
        RenderBugs();
        SendCompletePacket();
    }

    private void RenderBlocks() {
        int mapSize = 100;
        for(int y=0 ; y<mapSize ; ++y) {
            for(int x=0 ; x<mapSize ; ++x) {
                blockObjects[y][x] = Instantiate(blockPrefab, new Vector3(x,-0.5f,100-y), Quaternion.Euler(0,0,0)) as GameObject;
                blockObjects[y][x].transform.parent = parent_blocks;
            }
        }
    }

    private void RenderCat() {

        catObject = Instantiate(catPrefab, ServerData.cat.GetUnityPosition(), Quaternion.Euler(0,0,0));
        catObject.transform.parent = parent_cat;        // 분류
        catObject.transform.name = ServerData.cat.id;   // 이름

    }

    private void RenderBugs() {
        foreach(KeyValuePair<string, Bug> bugPair in ServerData.bugs) {
            GameObject bug = Instantiate(bugPrefab, bugPair.Value.GetUnityPosition(), Quaternion.Euler(0,0,0)) as GameObject;
            bugObjectsDict.Add (bugPair.Value.id, bug);
            bug.transform.parent = parent_bug;          // 분류
            bug.transform.name = bugPair.Value.id;      // 이름
        }
    }

    private void SendCompletePacket() {
    }

}