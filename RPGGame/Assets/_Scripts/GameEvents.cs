using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    void Awake()
    {
        current =this;
    }

    public event Action<int> OnPlayerDamage;
    public event Action OnPlayerDeath;
    public event Action OnEnemyDeath;
    public event Action<int> OnLevelComplete;
    public event Action OnGameRestart;

    public void LevelCompleted(int index){
        if (OnLevelComplete != null){
            OnLevelComplete(index);
        }
    }
    public void PlayerGetsDamaged(int hp){
        if (OnPlayerDamage != null){
            OnPlayerDamage(hp);
        }
    }

    public void PlayerDied(){
        if (OnPlayerDeath != null){
            OnPlayerDeath();
        }
    }

    
    public void EnemyDied(){
        if (OnEnemyDeath != null){

        }
    }
}
