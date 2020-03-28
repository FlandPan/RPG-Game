using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    private GameObject _player;
    public GameObject storeUI;
    public GameObject mainUI;
    void Start()
    {
        _player = PlayerSingleton.player;
    }
    void Update()
    {
        if (_player == null){
            _player = PlayerSingleton.player;
        }
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
