using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUser : MonoBehaviour
{
    public GameObject Prefab_User;
    private float refreshTime=0;

    private GameObject UserPoint;

    private int tempX, tempY;

    // Start is called before the first frame update
    void Start()
    {
        UserPoint = Instantiate(Prefab_User,new Vector3(0,0,0),Quaternion.identity) as GameObject;
        if(MyClientData.userType == UserType.CAT) UserPoint.transform.localScale = new Vector3(16,16,0);
    }
    
    // Update is called once per frame

    void Update()
    {
        refreshTime-=Time.deltaTime;
        
        if(refreshTime<0){
            refreshTime=0.5f;

            if(MyClientData.userType==UserType.BUG){
                Bug tempBug;
                ServerData.bugs.TryGetValue(MyClientData.id,out tempBug);
                tempX=tempBug.position.x;
                tempY=tempBug.position.y;
                UserPoint.transform.position = new Vector3 (tempX,tempY,0);
            }
            
            else{
                tempX=ServerData.cat.position.x;
                tempY=ServerData.cat.position.y;
                UserPoint.transform.position = new Vector3 (tempX,tempY,0);
            }
            
        }//if
    }//Update
}
