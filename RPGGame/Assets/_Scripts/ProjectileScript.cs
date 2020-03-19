using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileScript : PlayerStats
{
    public static int Damage;

    void OnTriggerEnter2D(Collider2D other)
    {
        EnemyStats enemy = other.GetComponent<EnemyStats>();
        if (enemy != null)
        {
            enemy.TakeDamage(Damage * pDamage);
            Destroy(gameObject);
        }
    }
}
