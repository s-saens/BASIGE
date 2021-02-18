using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public InputField inputName;

    public void Save()
    {
        PlayerPrefs.SetString("Name", inputName.text);
    }

    public void Start()
    {
        if(PlayerPrefs.HasKey("Name")) 
        {   
            //... 서버로 이름보낼 코드
            SceneManager.LoadScene("MatchingScreenUI");     //매칭화면으로 전환
        }
    }

    public void cancel()
    {
        SceneManager.LoadScene("MainScreenUI");
        PlayerPrefs.DeleteAll();
    }
}