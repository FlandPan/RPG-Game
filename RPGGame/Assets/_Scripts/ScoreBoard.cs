using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    private GameObject _player;
    public GameObject scoreBoardUI;
    public GameObject mainUI;
    void Start()
    {
        _player = PlayerSingleton.player;
    }
    void Update()
    {
        if (_player == null)
        {
            _player = PlayerSingleton.player;
        }
    }
    public void Exit()
    {
        mainUI.SetActive(true);
        scoreBoardUI.SetActive(false);
    }
    public void OpenScoreBoard()
    {
        mainUI.SetActive(false);
        scoreBoardUI.SetActive(true);
    }
}