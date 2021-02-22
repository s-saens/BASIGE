using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPlayers : MonoBehaviour
{
    private float refreshTime=0;
    public GameObject Prefab_Bug;
    public GameObject Prefab_Cat;

    private Dictionary<string, GameObject> Bugs;
    private GameObject Cat;


    private int tempX;
    private int tempY;
    private int AliveBugs;


    // Start is called before the first frame update


    void Start()
    {
        Bugs = new Dictionary<string, GameObject>();

        ServerData.InitializeDummies();
        
        // Bug
        foreach(KeyValuePair<string, Bug> bugPair in ServerData.bugs) {
            GameObject tempObject = Instantiate(Prefab_Bug, new Vector3(0,0,0),Quaternion.identity) as GameObject;
            tempObject.transform.parent = this.transform;
            Bugs.Add(bugPair.Value.id, tempObject);
        }

        AliveBugs=30;
        Cat = Instantiate(Prefab_Cat,new Vector3(0,0,0),Quaternion.identity) as GameObject;
    }


    void Destroy_Dead_Bug(string[] dead_ids){

        for(int i=0 ; i<dead_ids.Length ; ++i) {

            GameObject destroyingObject;
            Bugs.TryGetValue(dead_ids[i], out destroyingObject);
            Destroy(destroyingObject);

        }
    }


    // Update is called once per frame
    void Update()
    {
        
        refreshTime-=Time.deltaTime;
        
        if(refreshTime<0){
            refreshTime=0.5f;

            int i=0;
            foreach(KeyValuePair<string, Bug> bugpair in ServerData.bugs){      //에러
                

                if(bugpair.Value.isAlive==false){
                    continue;
                }

                tempX = bugpair.Value.position.x;
                tempY = bugpair.Value.position.y;

                GameObject tempObject;
                Bugs.TryGetValue(bugpair.Value.id, out tempObject);
                tempObject.transform.position = new Vector3(tempX*2+1,-tempY*2-1,0);
                i++;
            }

            
            
            tempX = ServerData.cat.position.x;
            tempY = ServerData.cat.position.y;
            Cat.transform.position = new Vector3(tempX*2+4,-tempY*2-4,0);


        }
    }
}
