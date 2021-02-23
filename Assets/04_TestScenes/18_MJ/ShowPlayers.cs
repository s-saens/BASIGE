/*using System.Collections;
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
        // Bug
        foreach(KeyValuePair<string, Bug> bugPair in ServerData.bugs) {
            GameObject tempObject = Instantiate(Prefab_Bug, this.transform, false) as GameObject;
            Bugs.Add(bugPair.Value.id, tempObject);
            tempObject.transform.SetParent(this.transform,false);
        }

        AliveBugs=30;
        Cat = Instantiate(Prefab_Cat,this.transform,false) as GameObject;
        Cat.transform.SetParent(this.transform,false);
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
                tempObject.transform.localPosition = new Vector3(tempX*4+2,-tempY*4-2,0);
                i++;
            }

            
            
            tempX = ServerData.cat.position.x;
            tempY = ServerData.cat.position.y;
            Cat.transform.localPosition = new Vector3(tempX*4+8,-tempY*4-8,0);


        }
    }
}*/
