using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    private Text _healthText;
    public int _hp = 1;
    public Text portalText;
    public Text damageText;
    private int pDamage;
    void Start()
    {
        GameEvents.current.OnPlayerDamage += DecreaseHealth;
        _hp = PlayerSingleton.player.GetComponent<PlayerStats>().playerHealth;
        pDamage = PlayerSingleton.player.GetComponent<PlayerStats>().pDamage;
        _healthText = GameObject.Find("Health").GetComponent<Text>();
        portalText.enabled = false;
    }
    public void DisplayDamage(){
        int weaponChoice = PlayerSingleton.player.GetComponent<PlayerAttack>().weaponChoice;
        int weaponDamage = 1;
        switch (weaponChoice)
        {
            case 0:
                weaponDamage = PencilScript.Damage;
                break;
            case 1:
                weaponDamage = FireScript.Damage;
                break;
            case 2:
                weaponDamage = BoltScript.Damage;
                break;
            case 3:
                weaponDamage = BoomerangScript.Damage;
                break;
        }
        damageText.text = "Damage: " + (pDamage*weaponDamage);
    }
    void Update()
    {
        _healthText.text = "HP: " + _hp;
        DisplayDamage();
        if (_hp == 0){
            GameEvents.current.PlayerDied();
            PlayerSingleton.player.GetComponent<PlayerMovement>().DisableInputs();
            PlayerSingleton.player.GetComponent<PlayerAttack>().DisableInput();
        }
    }
    private void DecreaseHealth(int hp){
        if(_hp >= hp){
            _hp -= hp;
        }
        else{
            _hp = 0;
        }
    }
    public void Display(string location){
        portalText.enabled = true;
        portalText.text = "Press E to teleport to " + location;
    }
    public void DisplayExit(){
        portalText.enabled = false;
    }
}
