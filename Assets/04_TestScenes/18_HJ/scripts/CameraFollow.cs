using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    public void Start()
    {
        player = GameObject.Find(ClientData.id);
        Camera camera;
        camera = this.transform.GetChild(0).GetComponent<Camera>();
        if(ClientData.userType == UserType.CAT){
            camera.orthographicSize=10;
        }
        if(ClientData.userType == UserType.BUG){
            camera.orthographicSize=5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pre=this.transform.position;
        Vector3 des=new Vector3(player.transform.position.x+2,player.transform.position.y+1,player.transform.position.z-1);
        this.transform.position=Vector3.Lerp(pre,des,Time.deltaTime);
    }
}
