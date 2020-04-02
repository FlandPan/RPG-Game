using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectiles : MonoBehaviour
{
    private int Damage = 8;
        
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == PlayerSingleton.player){
            GameEvents.current.PlayerGetsDamaged(Damage);
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
