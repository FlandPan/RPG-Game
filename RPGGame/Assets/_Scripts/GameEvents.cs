﻿using System;
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

    public event Action OnPlayerDamage;

    public void playerGetsDamaged(){
        if (OnPlayerDamage != null){
            OnPlayerDamage();
        }
    }
}