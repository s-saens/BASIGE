using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverScreen : MonoBehaviour
{

    public void SPMButton(){
        SceneManager.LoadScene("SwitchingCamera");

    }

    public void ExitButton(){
        SceneManager.LoadScene("MainJI");
    }
}