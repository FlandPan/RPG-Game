using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class CoinLevelManager : MonoBehaviour
{
    private static int _totalCoins;
    private int _startTime;
    private int scr;
    private static bool[] _completedLevels = new bool[9];
    void Start()
    {
        GameEvents.current.OnLevelComplete += addCoins;
        _startTime = (int)Mathf.Round((float)Timer.TimeLeft.TotalSeconds);
    }
    void Update()
    {
        if (_completedLevels[1] && _completedLevels[2] && SceneManager.GetActiveScene().name != "Hub" && SceneManager.GetActiveScene().name != "Boss"){
            SceneManager.LoadScene("Hub");
            Timer.StartCountDown(new System.TimeSpan(0,0,10));
            if (BossHits.getHP() == 0) {
                scr = (int)Math.Floor(Timer.TimeLeft.TotalSeconds * 100);
                timeScore(scr);
            }
        }
    }

    public static void timeScore(int timeScr){
        Score.number = timeScr;
    }

    public static void ResetLevels(){
        for (int i = 0; i < 9; i++)
        {
            _completedLevels[i] = false;
        }
    }
    public static void ResetCoins(){
        _totalCoins = 0;
    }
    public void addCoins(int index){
        int currentTime = (int)Mathf.Round((float)Timer.TimeLeft.TotalSeconds);
        int deltaTime = _startTime-currentTime;
        //DLS room
        if (index == 1 && !_completedLevels[index]){
            if (deltaTime > 60){
                _totalCoins += 5;
            }
            else if (deltaTime > 30){
                _totalCoins += 10;
            }
            else{
                _totalCoins += 20;
            }
            _completedLevels[1] = true;
        }
        //Snake Room
        if (index == 2 && !_completedLevels[index]){

            if (deltaTime > 60){
                _totalCoins += 5;
            }
            else if (deltaTime > 30){
                _totalCoins += 10;
            }
            else{
                _totalCoins += 20;
            }
            _completedLevels[2] = true;
        }
    }
    public bool canBuy(int num){
        return _totalCoins >= num;
    }
    public void subtractCoins(int num){
        _totalCoins -= num;
    }
    public int getCoins(){
        return _totalCoins;
    }
}
