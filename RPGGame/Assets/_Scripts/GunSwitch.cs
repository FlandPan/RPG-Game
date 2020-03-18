using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitch : MonoBehaviour
{
    public GameObject player;
    void Update() {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayerAttack pm = player.GetComponent<PlayerAttack>();
            pm.setWeaponChoice(1);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlayerAttack pm = player.GetComponent<PlayerAttack>();
            pm.setWeaponChoice(0);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            PlayerAttack pm = player.GetComponent<PlayerAttack>();
            pm.setWeaponChoice(0);
        }
    }
    public void Switch(){
        if(transform.position.x < 170)
        {
            PlayerAttack pm = player.GetComponent<PlayerAttack>();
            pm.setWeaponChoice(1);
        }
        else if(transform.position.x >300)
        {
            PlayerAttack pm = player.GetComponent<PlayerAttack>();
            pm.setWeaponChoice(0);
        }
        else
        {
            PlayerAttack pm = player.GetComponent<PlayerAttack>();
        }
    }
}
