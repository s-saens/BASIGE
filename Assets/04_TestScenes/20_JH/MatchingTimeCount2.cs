using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchingTimeCount2 : MonoBehaviour
{
    public GUIText _guiTime;
// Update is called once per frame
    void Update ()
    {
        _timeCnt += Time.deltaTime;
    }
 
 
    /// <summary>
    /// Raises the GU event.
    /// 시간표시
    /// </summary>
    void OnGUI()
    {
        string timeStr;
        timeStr = "" + _timeCnt.ToString("00.00");
        timeStr = timeStr.Replace(".",":");
        _guiTime.text = "Time : " + timeStr;
    }

}
