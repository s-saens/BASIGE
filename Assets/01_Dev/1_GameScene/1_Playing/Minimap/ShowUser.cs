using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUser : MonoBehaviour
{
    public GameObject Prefab_User;
    private float refreshTime=0;

    private GameObject UserPoint;

    // Start is called before the first frame update
    void Start()
    {
        UserPoint = Instantiate(Prefab_User,this.transform,false) as GameObject;

        if(ServerData.myClient.type == UserType.CAT) UserPoint.transform.localScale = new Vector3(4,4,0);

        UserPoint.transform.SetParent(this.transform,false);
    }
    
    // Update is called once per frame

    void Update()
    {
        refreshTime-=Time.deltaTime;
        
        if(refreshTime<0){

            int tempX = 0;
            int tempY = 0;

            refreshTime=0.5f;

            User myUser = ServerData.myClient;

            switch(myUser.type) {

                case UserType.BUG :
                    tempX = myUser.position.x * 4 + 2;
                    tempY = - myUser.position.y * 4 - 2;
                    break;
                case UserType.CAT :
                    tempX = myUser.position.x * 4 + 8;
                    tempY = - myUser.position.y * 4 - 8;
                    break;

            }

            UserPoint.transform.localPosition = new Vector3 (tempX,tempY);
            
        }//if
    }//Update
}
