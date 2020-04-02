using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class snakeHits : MonoBehaviour
{
    private static int health = 100;
    public Text snakeHP;
    public GameObject winUI;

    void Awake()
    {
        health = 100;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Attack")
        {
        for(int x =0; x < PlayerSingleton.player.GetComponent<PlayerStats>().pDamage;x++)
        {
            health--;
        }
        
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
            winUI.SetActive(true);
        }
        snakeHP.text = "Snake HP: " + health;
    }
    public void Home(){
        SceneManager.LoadScene("Hub");
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject == PlayerSingleton.player){
            GameEvents.current.PlayerGetsDamaged(10);
        }
    }
}
