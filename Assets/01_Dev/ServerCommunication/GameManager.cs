using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    // must be assigned in the inspector
    public GameObject blockPrefab;
    public GameObject catPrefab;
    public GameObject bugPrefab;

    [HideInInspector]
    private GameObject parent_blocks;
    [HideInInspector]
    private GameObject parent_cat;
    [HideInInspector]
    private GameObject parent_bug;

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

    public void FindParentObjectsInScene() {
        parent_blocks = GameObject.Find("02_Map");
    }

    public void Render() {
        
    }

}