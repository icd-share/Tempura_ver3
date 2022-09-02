using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeDisplay : MonoBehaviour
{
    private Text _timeText;
    [SerializeField] GameObject _timeTextObject; 

    void Start()
    {
        _timeText = _timeTextObject.GetComponent<Text>();
    }

    public void timeDisplay(float _totalTime)//合計時間を受け取りテキストを変える関数（板倉追記）
    {
        _timeText.text = _totalTime.ToString("F2") + "[s]"; //textに代入
    } 
}
