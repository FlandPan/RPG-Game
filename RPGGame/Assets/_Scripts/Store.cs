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
    public Text coinText;
    public Text canBuy;
    public Text cannotBuy;
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
        coinText.text = "Coins: " + _coinManager.getCoins();
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
        if (_coinManager.canBuy(10)){
            _player.GetComponent<PlayerAttack>()._maxShootSpd = (_player.GetComponent<PlayerAttack>()._maxShootSpd / 6) * 5;
            _player.GetComponent<PlayerAttack>()._maxBurnSpd = (_player.GetComponent<PlayerAttack>()._maxBurnSpd / 6) * 5;
            _player.GetComponent<PlayerAttack>()._maxBoltSpd = (_player.GetComponent<PlayerAttack>()._maxBoltSpd / 6) * 5;
            _coinManager.subtractCoins(10);
            canBuy.gameObject.SetActive(true);
            Invoke("_CanBuy",1);
        }else{
            cannotBuy.gameObject.SetActive(true);
            Invoke("_CannotBuy",1);
        }
    }
    private void _CannotBuy(){
        cannotBuy.gameObject.SetActive(false);
    }
    private void _CanBuy(){
        canBuy.gameObject.SetActive(false);
    }
    public void StatButton2(){
        if (_coinManager.canBuy(15)){
            _player.GetComponent<PlayerMovement>().moveSpeed += 1f;
            _coinManager.subtractCoins(15);
            canBuy.gameObject.SetActive(true);
            Invoke("_CanBuy",1);
        }else{
            cannotBuy.gameObject.SetActive(true);
            Invoke("_CannotBuy",1);
        }
    }
    public void StatButton3(){
        if (_coinManager.canBuy(10)){
            _player.GetComponent<PlayerStats>().pDamage += 1;
            _coinManager.subtractCoins(10);
            canBuy.gameObject.SetActive(true);
            Invoke("_CanBuy",1);
        }else{
            cannotBuy.gameObject.SetActive(true);
            Invoke("_CannotBuy",1);
        }
    }
}
