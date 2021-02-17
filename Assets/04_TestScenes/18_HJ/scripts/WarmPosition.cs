using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarmPosition : MonoBehaviour
{
     GameObject cubeobject;
    // public FixedJoystick joystick;
    // Start is called before the first frame update
    void Start()
    {
        cubeobject=GameObject.Find("Warm");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position=cubeobject.transform.position;
    }
}
