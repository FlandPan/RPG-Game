using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    protected int Damage = 0;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == PlayerSingleton.player){
            GameEvents.current.PlayerGetsDamaged(Damage);
        }
    }
    //For each projectile override this method with stats, etc.
    public void ProjectileDamage(int damage){
        //Multipliers
        Damage = damage;
    }
}
