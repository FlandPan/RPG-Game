using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitch : MonoBehaviour
{
    public GameObject player;
    void Update() {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayerMovement pm = player.GetComponent<PlayerMovement>();
            pm.setWeaponChoice(1);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlayerMovement pm = player.GetComponent<PlayerMovement>();
            pm.setWeaponChoice(0);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            PlayerMovement pm = player.GetComponent<PlayerMovement>();
            pm.setWeaponChoice(0);
        }
    }
    public void Switch(){
        Debug.Log(transform.position.x);
        if(transform.position.x < 170)
        {
            PlayerMovement pm = player.GetComponent<PlayerMovement>();
            pm.setWeaponChoice(1);
        }
        else if(transform.position.x >300)
        {
            PlayerMovement pm = player.GetComponent<PlayerMovement>();
            pm.setWeaponChoice(0);
        }
        else
        {
            PlayerMovement pm = player.GetComponent<PlayerMovement>();
        }
    }
}
