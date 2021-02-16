using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{

    public float speed;
    public FloatingJoystick joystick;
    public Rigidbody rb;
    public GameObject cube;


    void FixedUpdate()
    {
        Vector3 direction = Vector3.forward *0.1f* joystick.Vertical + Vector3.right *0.1f* joystick.Horizontal;
         Debug.Log("vertical : "+joystick.Vertical+" Horizontal : "+joystick.Horizontal);
          cube.transform.rotation=Quaternion.Slerp(cube.transform.rotation,Quaternion.LookRotation(direction),speed*Time.fixedDeltaTime);
          //rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
         cube.transform.localPosition+=direction;
    }
}
