using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
    public Text healthText;
    public GameObject deathScreen;
    public void Restart(){
        SceneManager.LoadScene("Hub");
    }
    void Update()
    {
        int hp = System.Int32.Parse(healthText.text.Split(' ')[1]);
        if (hp <= 0){
            deathScreen.SetActive(true);
            GameEvents.current.PlayerDied();
        }
    }
}
