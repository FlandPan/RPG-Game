using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int enemyHealth = 100;

    public int enemyDamage = 1;

    public GameObject deathEffect;

    public void TakeDamage(int damage){
        enemyHealth -= damage;

        if (enemyHealth <= 0){
            Die();
        }
    }

    void Die(){
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameEvents.current.PlayerGetsDamaged(enemyDamage);
        }
    }
}
