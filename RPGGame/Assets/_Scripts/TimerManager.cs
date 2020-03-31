using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    private Text _timerText;
    private bool _gameRestarted;
    public GameObject canvas;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(canvas);
        _timerText = this.gameObject.GetComponent<Text>();
        GameEvents.current.OnPlayerDeath += GameRestarted;
        if (!_gameRestarted){
            Timer.StartCountDown(new System.TimeSpan(0,5,0));
            _gameRestarted = true;
        }
    }
    public void GameRestarted(){
        _gameRestarted = false;
    }
    void Update()
    {
        _timerText.text = "Timer: " + Mathf.Round((float)Timer.TimeLeft.TotalSeconds);
    }
}
