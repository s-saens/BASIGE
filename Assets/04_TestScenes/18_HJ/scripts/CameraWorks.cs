using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWork : MonoBehaviour
{
   GameObject player;
   public Transform camerapivot;
   bool isActive=false;

    // Start is called before the first frame update
    public void setCamera()
    {
        if(MyClientData.userType==UserType.CAT){
            Debug.Log(MyClientData.userType);
            camerapivot.GetChild(0).GetComponent<Camera>().orthographicSize=15;
            player=InGameData.catObject;
            Debug.Log(player);
        }
        if(MyClientData.userType==UserType.BUG){
            Debug.Log(MyClientData.userType);
            camerapivot.GetChild(0).GetComponent<Camera>().orthographicSize=5;
            InGameData.bugObjectsDict.TryGetValue(MyClientData.id,out player);
            Debug.Log(player);
        }
        isActive=true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isActive) return;
        Vector3 pre=camerapivot.position;
        camerapivot.position=Vector3.Lerp(pre, player.transform.position,3*Time.deltaTime);
    }
}
