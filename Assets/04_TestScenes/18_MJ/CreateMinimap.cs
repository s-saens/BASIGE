using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMinimap : MonoBehaviour
{
    public GameObject Map_prefab_Area;
    public GameObject Map_prefab_Bug;
    public GameObject Map_prefab_Cat;
    private GameObject[][] MapFrame;
    private float refreshTime=0;



    void RenderMap(GameObject[][] Map){
        for(int i=0;i<5;i++){
            for(int j=0;j<5;j++){
                Map[j][i] = Instantiate(Map_prefab_Area,new Vector2(40+80*j,-(40+80*i)),Quaternion.identity) as GameObject; //����
            }
        }
    }

    void initialize(GameObject[][] Map){
        // block ���ӿ�����Ʈ ũ�� ����

        Map = new GameObject[ServerData.mapSize/20][];

        for(int i=0 ; i<ServerData.mapSize/20 ; ++i) {
            Map[i] = new GameObject[ServerData.mapSize/20];
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        initialize(MapFrame);
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

                    //�� ĭ(20*20)�� �ִ� �����Ϳ��� ������� ������ ���
                    
                    int TemporalRateOfBlock=0;

                    for(int j=0;j<20;j++){
                        for(int i=0;i<20;i++){
                            Bug tempBug;
                            ServerData.bugs.TryGetValue(ServerData.blocks[w*20+i][h*20+j].owner,out tempBug);   //����
                            if(tempBug.userType==UserType.CAT)
                                TemporalRateOfBlock++;
                            else if(tempBug.userType==UserType.BUG)
                                TemporalRateOfBlock--;
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
