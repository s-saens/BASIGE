using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove2 : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        
    }
    public float speed;
    public FixedJoystick joystick;
    public Rigidbody rb;
    public GameObject cube;
    public Animator anim;
    private bool isMove;
// Start is called before the first frame update
    void Start()
    {
       anim=GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float dirx=joystick.Horizontal;
        float dirz=joystick.Vertical;
        Debug.Log("x : "+dirx+" z: "+dirz);
        anim.SetBool("Forward",false);
        anim.SetBool("Right",false);
        anim.SetBool("Left",false);
        anim.SetBool("Back",false);
        Vector3 direction=new Vector3(joystick.Horizontal,0,joystick.Vertical);
         if(direction!=Vector3.zero){
             if(Mathf.Abs(dirx)<0.2f&&dirz>0.9f){
                anim.SetBool("Forward",true);
                this.transform.rotation=Quaternion.Euler(0,0,0);
             }
             else if(dirx>0.9f&&Mathf.Abs(dirz)<0.2f){
                anim.SetBool("Right",true);
                this.transform.rotation=Quaternion.Euler(0,90,0);
             }
             else if(dirx<-0.9f&&Mathf.Abs(dirz)<0.2f){
                anim.SetBool("Left",true);
                this.transform.rotation=Quaternion.Euler(0,-90,0);
             }
             else if(Mathf.Abs(dirx)<0.2f&&dirz<-0.9f){
                anim.SetBool("Back",true);
                this.transform.rotation=Quaternion.Euler(0,180,0);
             }
         }
        


    }
}
