using UnityEngine;
using System.Collections.Generic;

public class GameRenderer : MonoBehaviour {

    // must be assigned in the inspector
    public GameObject blockPrefab;
    public GameObject userPrefab;

    private GameObject parent_blocks;
    private GameObject parent_users;

    private GameObject[][] blockObjects;
    private Dictionary<string, GameObject> users;

    public void Start() {

        parent_blocks = new GameObject("Parent_Blocks");
        parent_blocks = new GameObject("Parent_Users");
        userPrefab = Resources.Load("/") as GameObject;

        ServerHandler.socket.On("initialize-layout", ()=> {
            Render();
        });
    }

    public void Render() {

        // blocks
        Block[][] serverBlocks = ServerData.blocks;

        for(int i=0 ; i<serverBlocks.GetLength(0) ; ++i) {
            for(int j=0 ; j<serverBlocks.GetLength(1) ; ++j) {

                blockObjects[i][j] = Instantiate(blockPrefab, new Vector3(j, 0, i), Quaternion.Euler(0,0,0), parent_blocks.transform) as GameObject;
                blockObjects[i][j].name = "Block(" + i + ", " + j + ")";

            }
        }

        //users
        Dictionary<string, User> serverUsers = ServerData.users;

        foreach(KeyValuePair<string, User> serverUserPair in serverUsers) {

            string serverUserID = serverUserPair.Key;
            User serverUser = serverUserPair.Value;

            GameObject user;
            user = Instantiate(userPrefab, serverUser.getPosition(), serverUser.getRotation(), parent_users.transform) as GameObject;
            user.name = "ID : " + serverUserID;
            users.Add(serverUserID, user);
        }
    }

}