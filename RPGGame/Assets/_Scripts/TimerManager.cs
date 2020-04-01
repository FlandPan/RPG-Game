using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    private Text _timerText;
    private static bool _gameRestarted;
    public GameObject canvas;
    private static TimerManager current;
    void Awake()
    {
        if (current != null){
            Destroy(this.gameObject);
            Destroy(this.transform.parent.gameObject);
        }
        else{
            current = this;
        }
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(canvas);
        _timerText = this.gameObject.GetComponent<Text>();
        if (!_gameRestarted){
            Timer.StartCountDown(new System.TimeSpan(0,5,0));
            _gameRestarted = true;
        }
    }
    public static void GameRestarted(){
        _gameRestarted = false;
    }
    void Update()
    {
        _timerText.text = "Timer: " + Mathf.Round((float)Timer.TimeLeft.TotalSeconds);
    }
}
