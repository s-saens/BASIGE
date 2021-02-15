using UnityEngine;
using System.Collections.Generic;

public class GameRenderer : MonoBehaviour {

    // must be assigned in the inspector
    public GameObject blockPrefab;
    public GameObject catPrefab;
    public GameObject bugPrefab;

    private GameObject parent_blocks;
    public GameObject parent_cat;
    public GameObject parent_bug;

    private GameObject[][] blockObjects;
    public GameObject cat;
    private Dictionary<string, GameObject> bugs;

    public void Start() {

        this.transform.position = new Vector3(0,0,0);

        parent_blocks = new GameObject("Parent_Blocks");
        parent_blocks = new GameObject("Parent_Creatures");
        catPrefab = Resources.Load("/") as GameObject;

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
        Dictionary<string, Creature> serverCreatures = ServerData.users;

        foreach(KeyValuePair<string, Creature> serverCreaturePair in serverCreatures) {

            string serverCreatureID = serverCreaturePair.Key;
            Creature serverCreature = serverCreaturePair.Value;

            GameObject user;
            user = Instantiate(catPrefab, serverCreature.GetUnityPosition(), serverCreature.GetUnityRotation(), parent_bug.transform) as GameObject;
            user.name = "ID : " + serverCreatureID;
            bugs.Add(serverCreatureID, user);
        }
    }

}