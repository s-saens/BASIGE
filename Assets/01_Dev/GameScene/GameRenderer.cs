// ATTACH THIS TO GameManager OBJECT //

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class GameRenderer : MonoBehaviour {

    // must be assigned in the inspector
    public GameObject blockPrefab;
    public GameObject bugPrefab;
    public GameObject catPrefab;

    public Transform parent_blocks;
    public Transform parent_bug;
    public Transform parent_cat;

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
                GameObject block = Instantiate(blockPrefab, new Vector3(x,-0.5f,100-y), Quaternion.Euler(0,0,0)) as GameObject;
                InGameData.blockObjects[y][x] = block;
                InGameData.blockObjects[y][x].transform.parent = parent_blocks;
            }
        }
    }

    private void RenderCat() {
        GameObject cat = Instantiate(catPrefab, ServerData.cat.GetUnityPosition(), Quaternion.Euler(0,0,0));
        InGameData.catObject = cat;
        InGameData.catObject.transform.parent = parent_cat;        // 분류
        InGameData.catObject.transform.name = ServerData.cat.id;   // 이름

    }

    private void RenderBugs() {

        foreach(KeyValuePair<string, Bug> bugPair in ServerData.bugs) {

            GameObject bug = Instantiate(bugPrefab, bugPair.Value.GetUnityPosition(), Quaternion.Euler(0,0,0)) as GameObject;
            InGameData.bugObjectsDict.Add (bugPair.Value.id, bug);
            bug.transform.parent = parent_bug;          // 분류
            bug.transform.name = bugPair.Value.id;      // 이름

        }

    }

    private void SendCompletePacket() {

        JObject jObject = new JObject();
        jObject.Add("gameId", ServerData.gameId);
        jObject.Add("complete", true);
        ServerData.socket.EmitJson("render_complete", jObject.ToString(Formatting.None)); // 인덴트 없이 보내기
    }

}