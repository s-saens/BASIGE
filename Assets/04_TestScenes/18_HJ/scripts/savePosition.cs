using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class savePosition : MonoBehaviour
{
    GameObject catObject;
    // public FixedJoystick joystick;
    // Start is called before the first frame update
    void Start()
    {
        catObject=GameObject.Find("Cube");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 position=new Vector3(catObject.transform.position.x,catObject.transform.position.y+1.5f,catObject.transform.position.z);
        transform.position=position;
    }
}
