using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MatchingTimeCount : MonoBehaviour
{
    float _Sec;
    int _Min;

    [SerializeField]
    Text _TimerText;

    private void update()
    {
        Timer();
    }

    void Timer()
    {
        _Sec += Time.deltaTime;
        _TimerText.text = string.Format("{0:D2}:{1:D2}", _Min, (int)_Sec);

        if((int)_Sec > 59)
        {
            _Sec = 0;
            _Min++;
        }
    }
}
