// ATTACH THIS TO GameManager OBJECT //

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class MoveManager : MonoBehaviour
{
    
    public Joystick joystick;
    public bool isActive = false;

    void Update()
    {
        if(!isActive) return;

        float dirx=joystick.Horizontal;
        float dirz=joystick.Vertical;

        Vector3 direction = new Vector3(joystick.Horizontal,0,joystick.Vertical);
        
        if(!ServerData.myClient.isMoving && direction!=Vector3.zero) { // 이미 움직이고있거나 조이스틱이 움직이지 않은 경우 제외

            Direction dir =0;
            float deadZone=0.2f;
            if(dirx>deadZone&&dirz>deadZone) dir=Direction.UP;
            if(dirx<-deadZone&&dirz<-deadZone) dir=Direction.DOWN;
            if(dirx<-deadZone&&dirz>deadZone) dir=Direction.LEFT;
            if(dirx>deadZone&&dirz<-deadZone) dir=Direction.RIGHT;

            JObject json = new JObject();
            json.Add("gameId", ServerData.gameId);
            json.Add("direction", (int)dir);
            ServerData.socket.EmitJson("move", json.ToString(Formatting.None));
        }
    }

    public IEnumerator Move(User user,Direction dir){

        GameObject player = InGameData.userObjects[user.id];
        int rotation=0;
        user.isMoving = true;

        switch(dir){
            case Direction.UP: rotation=0; break;
            case Direction.DOWN: rotation=180; break;
            case Direction.RIGHT: rotation=90; break;
            case Direction.LEFT: rotation=-90; break;
        }

        player.transform.rotation = Quaternion.Euler(0,rotation,0);

        Vector3 dest = player.transform.position + player.transform.forward;
        float dist = Vector3.Distance(player.transform.position,dest);
        float speed = ServerData.myClient.velocity * Time.deltaTime;

        while(dist >= 0.000001){

            dist=Vector3.Distance(player.transform.position,dest);
            if(dist>speed) player.transform.Translate(player.transform.forward*speed);
            else {
                player.transform.Translate(player.transform.forward*dist);
                //isMoving 켜기
            }
            yield return Deactivate(user);
        }
    }

    private IEnumerator Deactivate(User user) {
        for(int i=0; i<=0 ; ++i) {
            user.isMoving = false;
            yield return 0;
        }
    }
}
