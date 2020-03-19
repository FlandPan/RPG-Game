using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
   public int playerHealth = 100;
   public int pDamage = 2;
   public int armor;

    public void TakePDamage(int damage)
    {
        playerHealth -= damage;

        if (playerHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}