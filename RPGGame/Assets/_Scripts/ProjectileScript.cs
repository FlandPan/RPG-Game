using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private int Damage = 0;
    void OnTriggerEnter2D(Collider2D other)
    {
        EnemyStats enemy = other.GetComponent<EnemyStats>();
        if (enemy != null)
        {
            enemy.TakeDamage(Damage);
        }
    }
    //For each projectile override this method with stats, etc.
    public int ProjectileDamage{
        get {
            return Damage;
        }
        set {
            //Put multipliers here
            Damage = value;
        }
    }
}
