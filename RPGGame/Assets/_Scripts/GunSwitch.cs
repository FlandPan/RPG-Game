using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitch : MonoBehaviour
{
    public GameObject player;
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
        Debug.Log("Switched null");
            PlayerMovement pm = player.GetComponent<PlayerMovement>();
        }
    }
}
