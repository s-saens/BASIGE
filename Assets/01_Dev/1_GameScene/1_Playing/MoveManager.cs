// ATTACH THIS TO GameManager OBJECT //

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class MoveManager : MonoBehaviour
{
    
    // Joystick Move Packet Send
    public FixedJoystick joystick;
    Direction tempdir=0;
    void Update()
    {
        float dirx=joystick.Horizontal;
        float dirz=joystick.Vertical;
        Vector3 direction=new Vector3(joystick.Horizontal,0,joystick.Vertical);

        if(direction!=Vector3.zero){

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



    public void movePlayer(GameObject player, Direction dir){
        changeRotation(player, dir);
    }

    public void changeRotation(GameObject player,Direction dir){
        int rotation=0;

        switch(dir){
            case Direction.UP: rotation=0; break;
            case Direction.DOWN: rotation=180; break;
            case Direction.RIGHT: rotation=90; break;
            case Direction.LEFT: rotation=-90; break;
        }
        tempdir=dir;
        Tween tween=player.transform.DORotate(new Vector3(0,rotation,0),1f);
        tween.OnComplete(()=>{
            StartCoroutine(Move(player,dir));
        });
    }

    public IEnumerator Move(GameObject player,Direction dir){
        Vector3 dest=player.transform.position+player.transform.forward;
        float dist=Vector3.Distance(player.transform.position,dest);
        float speed=4*Time.deltaTime;

        while(dist>=0.000001){
            dist=Vector3.Distance(player.transform.position,dest);
            if(dist>speed) player.transform.Translate(player.transform.forward*speed);
            else player.transform.Translate(player.transform.forward*dist);
            yield return 0;
        }
    }
}