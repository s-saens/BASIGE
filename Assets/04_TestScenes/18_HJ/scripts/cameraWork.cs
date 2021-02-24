using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWork : MonoBehaviour
{
   GameObject player;
   public Transform camerapivot;
    // Start is called before the first frame update
    public void Start()
    {
        if(MyClientData.userType==UserType.CAT){
            Debug.Log(MyClientData.userType);
            camerapivot.GetChild(0).GetComponent<Camera>().orthographicSize=10;
            player=InGameData.catObject;
            Debug.Log(player);
        }
        if(MyClientData.userType==UserType.BUG){
            Debug.Log(MyClientData.userType);
            camerapivot.GetChild(0).GetComponent<Camera>().orthographicSize=5;
            InGameData.bugObjectsDict.TryGetValue(MyClientData.id,out player);
             Debug.Log(player);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pre=camerapivot.position;
        camerapivot.position=Vector3.Lerp(pre, player.transform.position,Time.deltaTime);
    }
}
