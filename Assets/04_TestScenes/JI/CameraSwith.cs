using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraSwith : MonoBehaviour
{
    
    public float cameraSpeed = 10;
    public Camera cam;
    public Vector3 targetPosition;
    
    public int x = 0;
    public GameObject player1;
    public GameObject player2;

    public void Next(){ 
        
        if(x>=1) x = 0;
        else x++;
        ClickEvent(x);
    }

    public void Previous(){  
        
        if(x<=0) x = 1;
        else x--;
        ClickEvent(x);
    }
    public int ClickEvent(int x)
    {
        switch(x)
        {
            case 0: 
            if (player1.gameObject != null)
            {
            cam.transform.SetParent(player1.transform);
            targetPosition.Set(player1.transform.position.x,player1.transform.position.y + 4.32f,player1.transform.position.z - 13);
            cam.transform.position = Vector3.Lerp(cam.transform.position,targetPosition,cameraSpeed);
            }
            break;
            case 1:  
            if (player2.gameObject != null)
            {
            cam.transform.SetParent(player2.transform);
            targetPosition.Set(player2.transform.position.x,player2.transform.position.y + 4.32f,player2.transform.position.z - 13);
            cam.transform.position = Vector3.Lerp(cam.transform.position,targetPosition,cameraSpeed);
            }
            break;


        }
        return 0;
    }
  

    public void ExitButton(){
        SceneManager.LoadScene("MainJI");
    }
}
