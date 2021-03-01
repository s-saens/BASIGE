using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountUpTimer : MonoBehaviour
{
    public Text timer;
    public float time;
    float sec;
    float min;

    public void CountStart()
    {
        StartCoroutine("StopWatch");
    }

    public void StopWatchStop()
    {
        StopCoroutine("StopWatch");
        time = 0;
        timer.text = "00:00";
    }

    IEnumerator StopWatch()
    {
        while (true) 
        {
            time += Time.deltaTime;
            sec = (int)(time % 60);
            min = (int)(time / 60 % 60);

            timer.text = string.Format("{0:00}:{1:00}", min, sec);

            yield return null;
        }
    }
}
