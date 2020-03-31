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
        Destroy(PlayerSingleton.player);
    }
    void Start()
    {
        GameEvents.current.OnPlayerDeath += Death;
    }
    public void Death(){
        deathScreen.SetActive(true);
    }
}
