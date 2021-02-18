using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraSwith : MonoBehaviour
{
    
    public GameObject cam1;
    public GameObject cam2;

    public void scam1(){
        cam1.SetActive(true);
        cam2.SetActive(false);
    }

    public void scam2(){
        cam1.SetActive(false);
        cam2.SetActive(true);
    }

    public void ExitButton(){
        SceneManager.LoadScene("MainJI");
    }
}
