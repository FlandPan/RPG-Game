using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private Text _timer;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        _timer = this.GetComponentInChildren<Text>();
        Timer.StartCountDown(new System.TimeSpan(0,2,0));
    }
    void Update()
    {
        _timer.text = "Timer: " + Mathf.Round((float)Timer.TimeLeft.TotalSeconds);
    }
}
