using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : PlayerStats
{
    private Text _timer;
    private Text _healthText;
    public int _hp = 1;
    public Text PortalText;
    void Start()
    {
        GameEvents.current.OnPlayerDamage += DecreaseHealth;
        _timer = GameObject.Find("Timer").GetComponent<Text>();
        _hp = PlayerSingleton.player.GetComponent<PlayerStats>().playerHealth;
        _healthText = GameObject.Find("Health").GetComponent<Text>();
        Timer.StartCountDown(new System.TimeSpan(0,2,0));
        PortalText.enabled = false;
    }
    void Update()
    {
        _timer.text = "Timer: " + Mathf.Round((float)Timer.TimeLeft.TotalSeconds);
        _healthText.text = "HP: " + _hp;
        if (_hp == 0){
            GameEvents.current.PlayerDied();
            PlayerSingleton.player.GetComponent<PlayerMovement>().DisableInputs();
            PlayerSingleton.player.GetComponent<PlayerAttack>().DisableInput();
        }
    }
    private void DecreaseHealth(int hp){
        if(_hp >= hp){
            _hp -= hp;
        }
        else{
            _hp = 0;
        }
    }
    public void Display(string location){
        PortalText.enabled = true;
        PortalText.text = "Press E to teleport to " + location;
    }
    public void DisplayExit(){
        PortalText.enabled = false;
    }
}
