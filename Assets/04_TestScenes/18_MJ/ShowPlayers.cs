using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct Players{
    public GameObject Tile;
    public int xpos;
    public int ypos;
    public bool IsItLive;

}
public class ShowPlayers : MonoBehaviour
{
    public float refreshTime=0;
    public GameObject Prefab_Bug;
    public GameObject Prefab_Cat;

    private Players[] Bugs = new Players[30]; 

    private Players Cat;


    // Start is called before the first frame update

    void InitializePlayers(Players A, GameObject X){
        A.xpos=0;
        A.ypos=0;
        A.IsItLive=true;
        A.Tile = Instantiate(X,new Vector3(A.xpos,A.ypos,0),Quaternion.identity);
    }

    void Start()
    {
        for(int i=0;i<30;i++){
            InitializePlayers(Bugs[i],Prefab_Bug);
        }
        InitializePlayers(Cat,Prefab_Cat);
    }

    // Update is called once per frame
    void Update()
    {
        
        refreshTime-=Time.deltaTime;
        
        if(refreshTime<0){
            refreshTime=0.5f;

            // for(int i=0;i<30;i++){
            //     if(Bugs[i].IsItLive==false) continue;

            //     Bugs[i].xpos = 1; // =SeverData.users[i].Postion.x;
            //     Bugs[i].ypos = 1; // =SeverData.users[i].Postion.y;
            //     Bugs[i].Tile.transform.position = new Vector3(Bugs[i].xpos*2+1,-Bugs[i].ypos*2-1,0);
            //     Bugs[i].IsItLive = true; // =SeverData.users[i].IsItLive;
            // }

            int temp=0;
            for(int i=0;i<100;i++){
                for(int j=0;j<100;j++){
                    if(ServerData.blocks[j][i].isOwnerStand==true&&ServerData.blocks[j][i].id=="Bug"){
                        Bugs[temp].xpos = j;
                        Bugs[temp].ypos = i;
                        temp++;
                    }
                    else if(ServerData.blocks[j][i].isOwnerStand==true&&ServerData.blocks[j][i].id=="Cat"){
                        
                        Cat.xpos = j-8;
                        Cat.ypos = i-8;
                    }
                }
            }
            Cat.Tile.transform.position = new Vector3(8+Cat.xpos*2,-8-Cat.ypos*2,0);
        }
    }
}
