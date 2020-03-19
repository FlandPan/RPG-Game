using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public GameObject boy;
    public GameObject girl;
    private GameObject _player;

    void Start() {
        _player = PlayerSingleton.player;
    }

    public void switchBoy() {
        _player = boy;
        this.gameObject.SetActive(false);
    }

    public void switchGirl() {
        _player = girl;
        this.gameObject.SetActive(false);
    }
}
