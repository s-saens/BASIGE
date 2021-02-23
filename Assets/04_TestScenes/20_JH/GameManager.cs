using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public InputField inputName;
    public GameObject EnterTheNameIMG;
    
    public void Save()
    {
        PlayerPrefs.SetString("Name", inputName.text);  //유저 이름받아 저장
    }

    public void GameStart()
    {
        if(inputName.text=="") 
        {   
            EnterTheNameIMG.gameObject.SetActive(true);  //이름이 공백인지 확인
        }
        else
        {
            string nickname = PlayerPrefs.GetString("Name");
            ServerHandler.socket.EmitJson("init", "{ nickname:" + nickname + " }");      //유저 이름 서버로 전송
            SceneManager.LoadScene("MatchingScreenUI");     //매칭화면으로 전환
        }
    }

    public void cancel()
    {
        SceneManager.LoadScene("MainScreenUI");    //매인화면으로 전환
        PlayerPrefs.DeleteAll();
        Debug.Log(PlayerPrefs.HasKey("Name"));  //닉네임 지워졌나 확인
    }

}