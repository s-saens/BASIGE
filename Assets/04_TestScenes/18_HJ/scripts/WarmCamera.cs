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
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=new Vector3(cube.transform.position.x,4,cube.transform.position.z-10.5f);
        transform.rotation=Quaternion.Euler(25, cube.transform.rotation.y,cube.transform.rotation.z);
    }
}
