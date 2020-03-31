using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinLevelManager : MonoBehaviour
{
    private int _totalCoins;
    private int _startTime;
    private Text _timer;
    private bool[] _completedLevels = new bool[9];
    void Start()
    {
        GameEvents.current.OnLevelComplete += addCoins;
        _timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Text>();
        _startTime = System.Int32.Parse(_timer.text.Split(' ')[1]);
    }

    public void addCoins(int index){
        //DLS room
        if (index == 1 && !_completedLevels[index]){
            int currentTime = System.Int32.Parse(_timer.text.Split(' ')[1]);
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
