using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossHits : MonoBehaviour
{

    private static int health = 2500;
    public Text bossHP;
    public GameObject winText;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Attack")
        {
         for(int x =0; x < ProjectileScript.Damage * PlayerSingleton.player.GetComponent<PlayerStats>().pDamage;x++)
        {
            health--;
        }
        if(other.name !="boomerang(Clone)")
        Destroy(other.gameObject);
        }   
    }
    public void Home(){
        SceneManager.LoadScene(0);
    }
    void Update()
    {
        if(health <= 0)
        {   
            GameObject temp = this.gameObject;
            Destroy(GameObject.Find("Projectile(Clone)"));
            temp.SetActive(false);
            winText.SetActive(true);
        }
        bossHP.text = "Boss HP: " + health;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject == PlayerSingleton.player){
            GameEvents.current.PlayerGetsDamaged(10);
        }
    }
    public static int getHP()
    {
        return health;
    }
}
