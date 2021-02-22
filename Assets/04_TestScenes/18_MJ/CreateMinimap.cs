using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct Point {public int x; public int y;}
public class CreateMinimap : MonoBehaviour
{
    public GameObject Map_prefab_Area;
    public GameObject Map_prefab_Bug;
    public GameObject Map_prefab_Cat;
    private GameObject[][] MapFrame;

    private float refreshTime=0;


    private int TemporalRateOfBlock;

    void RenderMap(GameObject[][] Map){
        for(int i=0;i<5;i++){
            for(int j=0;j<5;j++){
                Map[i][j] = Instantiate(Map_prefab_Area,new Vector2(40+80*j,-(40+80*i)),Quaternion.identity) as GameObject;
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        RenderMap(MapFrame);
    }
    
    // Update is called once per frame

    void Update()
    {
        refreshTime-=Time.deltaTime;
        
        if(refreshTime<0){
            refreshTime=0.5f;


            for(int h=0;h<5;h++){
                for(int w=0;w<5;w++){

                    //한 칸(20*20)에 있는 데이터에서 어느쪽이 많은지 계산
                    
                     TemporalRateOfBlock=0;


                    for(int j=0;j<20;j++){
                        for(int i=0;i<20;i++){
                            if(//ServerData.blocks[w*20+i][h*20+j].isFixed==) TemporalRateOfBlock++; else TemporalRateOfBlock--;
                        }
                    }


                    if(TemporalRateOfBlock>0){
                        MapFrame[w][h]=Instantiate(Map_prefab_Cat);
                    }
                    else if(TemporalRateOfBlock<0){
                        MapFrame[w][h]=Instantiate(Map_prefab_Bug);
                    }
                    else{
                        MapFrame[w][h]=Instantiate(Map_prefab_Area);
                    }


                }//for
            }//for
        }//if
    }//Update
}
