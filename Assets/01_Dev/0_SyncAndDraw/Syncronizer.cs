using UnityEngine;

public class Syncronizer : MonoBehaviour {

    [HideInInspector]
    public GameObject blocks_parent;
    public GameObject otherUsers_parent;
    public GameObject user;
    private GameObject[] blocks;
    private GameObject[] otherUsers;

    private void Start() {
        blocks = blocks_parent.GetComponentsInChildren<GameObject>();
        otherUsers = otherUsers_parent.GetComponentsInChildren<GameObject>();
    }

    public void SyncronizeAndDraw() {
        foreach(GameObject b in blocks) {
            
        }
    }

}