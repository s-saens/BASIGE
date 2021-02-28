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
    public GameObject wallObject;

    public Transform parent_blocks;
    public Transform parent_bug;
    public Transform parent_cat;

    public void Render() {

        RenderBlocks();
        RenderUsers();
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
        wallObject.SetActive(true);
    }

    private void RenderUsers() {

        foreach(KeyValuePair<string, User> userPair in ServerData.users) {

            GameObject prefab = null;

            switch(userPair.Value.type) {
                case UserType.CAT :
                    prefab = catPrefab;
                    break;
                case UserType.BUG :
                    prefab = bugPrefab;
                    break;
            }
            
            GameObject user = Instantiate(prefab, userPair.Value.GetUnityPosition(), Quaternion.Euler(0,0,0)) as GameObject;
            InGameData.userObjects.Add (userPair.Value.id, user);

            // 이름과 부모오브젝트 지정해주기
            user.transform.parent = parent_bug;          // 분류
            user.transform.name = userPair.Value.id;      // 이름

        }

    }

    private void SendCompletePacket() {

        JObject jObject = new JObject();
        jObject.Add("gameId", ServerData.gameId);
        jObject.Add("complete", true);
        ServerData.socket.EmitJson("render_complete", jObject.ToString(Formatting.None)); // 인덴트 없이 보내기
        Debug.Log(jObject.ToString());
    }

}