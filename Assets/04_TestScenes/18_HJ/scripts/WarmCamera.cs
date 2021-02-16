using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarmCamera : MonoBehaviour
{
    GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        cube=GameObject.Find("Warm");
        StartCoroutine(Move(new Vector3(0,0,4)));
        
    }

    public IEnumerator Move(Vector3 dest) {
        float dist = Vector3.Distance(cube.transform.position,dest);
        float speed = 4*Time.deltaTime;
        while(dist>=0.000001) {
            dist = Vector3.Distance(cube.transform.position,dest);
            if(dist > speed) cube.transform.Translate(cube.transform.forward * speed);
            else cube.transform.Translate(cube.transform.forward * dist);
            yield return 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=new Vector3(cube.transform.position.x,4,cube.transform.position.z-10.5f);
        transform.rotation=Quaternion.Euler(25, cube.transform.rotation.y,cube.transform.rotation.z);
    }
}
