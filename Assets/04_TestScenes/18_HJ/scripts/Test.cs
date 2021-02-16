using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public FixedJoystick joystick;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         
        if(joystick.Vertical>0.7&&Mathf.Abs(joystick.Horizontal)>0.7){//up
            anim.SetBool("Up",true);
        }
    }
}
