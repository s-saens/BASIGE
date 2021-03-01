using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateMinimap : MonoBehaviour
{

    public GameObject Map_prefab_Area;

    private GameObject[][] MapFrame;
    private float refreshTime=0;

    

    // Start is called before the first frame update
    void StartMinimap()
    {
        initialize();
        RenderMap();
    }

    void initialize(){
        
        MapFrame = new GameObject[ServerData.mapSize/20][];

        for(int i=0 ; i<ServerData.mapSize/20 ; ++i) {
            MapFrame[i] = new GameObject[ServerData.mapSize/20];
        }
    }

    void RenderMap(){
        for(int i=0;i<5;i++){
            for(int j=0;j<5;j++){
                MapFrame[j][i] = Instantiate(Map_prefab_Area,new Vector2(40+80*j,-(40+80*i)),Quaternion.identity) as GameObject; //����
                MapFrame[j][i].transform.SetParent(this.transform,false);
            }
        }
    }

    void Update()
    {
        refreshTime-=Time.deltaTime;
        
        if(refreshTime<0){
            refreshTime=0.5f;

            for(int h=0;h<5;h++){
                for(int w=0;w<5;w++){

                    //�� ĭ(20*20)�� �ִ� �����Ϳ��� �������? ������ ���?
                    
                    int TemporalRateOfBlock=0;

                    for(int j=0;j<20;j++){
                        for(int i=0;i<20;i++){

                            if(ServerData.blocks[w*20+i][h*20+j].owner != null) {

                                User user = ServerData.users[ServerData.blocks[w*20+i][h*20+j].owner];

                                switch(user.type) {

                                    case UserType.BUG :
                                        TemporalRateOfBlock++;
                                        break;
                                    case UserType.CAT :
                                        TemporalRateOfBlock--;
                                        break;

                                }
                            }
                        }
                    }


                    if(TemporalRateOfBlock>0){
                        MapFrame[w][h].GetComponent<RawImage>().color = new Color(255,78,0,255);
                    }
                    else if(TemporalRateOfBlock<0){
                        MapFrame[w][h].GetComponent<RawImage>().color = new Color(129,255,105,255);
                    }
                    else{
                        MapFrame[w][h].GetComponent<RawImage>().color = new Color(120,120,120,255);
                    }


                }//for
            }//for
        }//if
    }//Update
}
