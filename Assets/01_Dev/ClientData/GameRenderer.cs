using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameRenderer : MonoBehaviour {

    // must be assigned in the inspector
    public GameObject blockPrefab;
    public GameObject catPrefab;
    public GameObject bugPrefab;

    public Transform parent_blocks;
    public Transform parent_cat;
    public Transform parent_bug;

    private GameObject[][] blockObjects;
    public GameObject cat;
    private Dictionary<string, GameObject> bugs; // id, Bug 쌍


    public void Render() {
        RenderBlocks();
        RenderCat();
        RenderBugs();
        SendCompletePacket();
    }

    private void RenderBlocks() {
        int mapSize = 100;
        for(int y=0 ; y<mapSize ; ++y) {
            for(int x=0 ; x<mapSize ; ++x) {
                blockObjects[y][x] = Instantiate(blockPrefab, new Vector3(x,0,100-y), Quaternion.Euler(0,0,0)) as GameObject;
                blockObjects[y][x].transform.parent = parent_blocks;
            }
        }
    }

    private void RenderCat() {
        cat = Instantiate(catPrefab, ServerData.cat.GetUnityPosition(), Quaternion.Euler(0,0,0));
        cat.transform.parent = parent_cat;
    }

    private void RenderBugs() {
        foreach(KeyValuePair<string, Bug> bugPair in ServerData.bugs) {
            GameObject bug = Instantiate(catPrefab, bugPair.Value.GetUnityPosition(), Quaternion.Euler(0,0,0)) as GameObject;
            bugs.Add (bugPair.Value.id, bug);
            bug.transform.parent = parent_bug;
        }
    }

    private void SendCompletePacket() {
        ServerHandler.socket.EmitJson("render_complete", "{ gameId:"+ ~.id + ", complete:" + bool변수.ToString() + " }");
    }

}