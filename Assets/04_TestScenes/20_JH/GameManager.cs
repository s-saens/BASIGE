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
        PlayerPrefs.SetString("Name", inputName.text);  //���� �̸��޾� ����
    }

    public void GameStart()
    {
        if(inputName.text=="") 
        {   
            EnterTheNameIMG.gameObject.SetActive(true);  //�̸��� �������� Ȯ��
        }
        else
        {
            string nickname = PlayerPrefs.GetString("Name");
            ServerHandler.socket.EmitJson("init", "{ nickname:" + nickname + " }");      //���� �̸� ������ ����
            SceneManager.LoadScene("MatchingScreenUI");     //��Īȭ������ ��ȯ
        }
    }

    public void cancel()
    {
        SceneManager.LoadScene("MainScreenUI");    //����ȭ������ ��ȯ
        PlayerPrefs.DeleteAll();
        Debug.Log(PlayerPrefs.HasKey("Name"));  //�г��� �������� Ȯ��
    }

}