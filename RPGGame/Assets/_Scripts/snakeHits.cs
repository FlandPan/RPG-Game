using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class snakeHits : MonoBehaviour
{
    private static int health = 25;
    public Text snakeHP;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Attack")
        {
        health--;
        Debug.Log("snake hit");
        if(other.name != "boomerang(Clone)")
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
            
            PlayerAttack.BoomUnlocked(2);
            GameEvents.current.LevelCompleted(2);
        }
        snakeHP.text = "Snake HP: " + health;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject == PlayerSingleton.player){
            GameEvents.current.PlayerGetsDamaged(10);
        }
    }
}
