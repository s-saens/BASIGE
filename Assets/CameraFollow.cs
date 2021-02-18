using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
     GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.Find(MyClientData.id);
        Camera camera;
        camera=this.transform.GetChild(0).GetComponent<Camera>();
        if(MyClientData.userType==UserType.CAT){
            camera.orthographicSize=10;
        }
        if(MyClientData.userType==UserType.BUG){
            camera.orthographicSize=5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pre=this.transform.position;
        Vector3 des=new Vector3(player.transform.position.x+13,player.transform.position.y+8,player.transform.position.z-13);
        this.transform.position=Vector3.Lerp(pre,des,Time.deltaTime);
    }
}
