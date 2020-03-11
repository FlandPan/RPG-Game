using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private Text _timer;
    private Text _healthText;
    public int _hp = 100;
    public UIManager(){

    }
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        _timer = GameObject.Find("Timer").GetComponent<Text>();
        _healthText = GameObject.Find("Health").GetComponent<Text>();
        Timer.StartCountDown(new System.TimeSpan(0,2,0));

        GameEvents.current.OnPlayerDamage += decreaseHealth;
    }
    void Update()
    {
        _timer.text = "Timer: " + Mathf.Round((float)Timer.TimeLeft.TotalSeconds);
        _healthText.text = "HP:   " + _hp;
    }
    private void decreaseHealth(int hp){
        if(_hp >= hp)
            _hp -= hp;
    }
}
