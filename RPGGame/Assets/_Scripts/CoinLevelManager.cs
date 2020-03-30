using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinLevelManager : MonoBehaviour
{
    private int _totalCoins;
    private int _startTime;
    public Text timer;
    private bool[] _completedLevels = new bool[9];
    void Awake()
    {
        GameEvents.current.OnLevelComplete += addCoins;
        _startTime = System.Int32.Parse(timer.text.Split(' ')[1]);
    }

    public void addCoins(int index){
        //DLS room
        if (index == 1 && !_completedLevels[index]){
            int currentTime = System.Int32.Parse(timer.text.Split(' ')[1]);
            int deltaTime = _startTime-currentTime;
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
            Debug.Log(deltaTime);
            Debug.Log(_totalCoins);
        }
    }
}
