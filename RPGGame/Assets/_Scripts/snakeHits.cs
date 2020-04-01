using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakeHits : MonoBehaviour
{
    private static int health = 100;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Attack")
        {
        health--;
        Debug.Log("snake hit");
        Destroy(other.gameObject);
        }   
    }
    void Update()
    {
        if(health <= 0)
        {   
            GameObject temp = this.gameObject;
            Destroy(GameObject.Find("Projectile(Clone)"));
            temp.SetActive(false);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject == PlayerSingleton.player){
            GameEvents.current.PlayerGetsDamaged(10);
        }
    }
}
