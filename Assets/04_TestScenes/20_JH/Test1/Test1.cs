using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Test1 : MonoBehaviour
{

    [SerializeField] private Text txt_name;
    [SerializeField] private Image img_name;

    private bool isCoolTime = false;

    private float currentTime = 1f;

    void Update()
    {
        if(isCoolTime) {
            currentTime -= Time.deltaTime;
            img_name.fillAmount = currentTime;

            if(currentTime <= 0) {
                currentTime = 1f;
                img_name.fillAmount = currentTime;
                isCoolTime = false;
            }
        }
    }

    public void Change()
    {
        txt_name.text = "º¯°æµÊ";
        isCoolTime = true;
    }
}