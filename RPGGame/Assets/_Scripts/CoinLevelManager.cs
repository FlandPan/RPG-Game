using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinLevelManager : MonoBehaviour
{
    private static int _totalCoins;
    private int _startTime;
    private static bool[] _completedLevels = new bool[9];
    void Start()
    {
        GameEvents.current.OnLevelComplete += addCoins;
        _startTime = (int)Mathf.Round((float)Timer.TimeLeft.TotalSeconds);
    }
    void Update()
    {
        if (_completedLevels[1] && _completedLevels[2]){
            
        }
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
