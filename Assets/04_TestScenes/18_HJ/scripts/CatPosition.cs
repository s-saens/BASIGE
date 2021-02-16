using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPosition : MonoBehaviour
{
   GameObject cubeobject;
    // public FixedJoystick joystick;
    // Start is called before the first frame update
    void Start()
    {
        cubeobject=GameObject.Find("Cat");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position=cubeobject.transform.position;
    }
}
