using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    private GameObject _player;
    public GameObject storeUI;
    public GameObject mainUI;
    private CoinLevelManager _coinManager;
    public Text _coinText;
    void Start()
    {
        _player = PlayerSingleton.player;
        _coinManager = this.gameObject.GetComponent<CoinLevelManager>();
    }
    void Update()
    {
        if (_player == null){
            _player = PlayerSingleton.player;
        }
        _coinText.text = "Coins: " + _coinManager.getCoins();
    }
    public void Exit(){
        mainUI.SetActive(true);
        storeUI.SetActive(false);
    }
    public void OpenStore(){
        mainUI.SetActive(false);
        storeUI.SetActive(true);
    }
    public void StatButton1(){

    }
    public void StatButton2(){

    }
    public void StatButton3(){

    }
}
