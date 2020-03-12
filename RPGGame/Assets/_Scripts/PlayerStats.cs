using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
   public int maxHealth = 100;
   public int currentHealth { get; private set;}
   public Stat damage;
   public Stat armor;

    void Awake()
    {
        currentHealth = maxHealth;
    }
}
