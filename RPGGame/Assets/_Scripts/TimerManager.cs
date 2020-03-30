using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    private Text _timerText;
    public GameObject canvas;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(canvas);
        _timerText = this.gameObject.GetComponent<Text>();
        Timer.StartCountDown(new System.TimeSpan(0,5,0));
    }
    void Update()
    {
        _timerText.text = "Timer: " + Mathf.Round((float)Timer.TimeLeft.TotalSeconds);
    }
}
