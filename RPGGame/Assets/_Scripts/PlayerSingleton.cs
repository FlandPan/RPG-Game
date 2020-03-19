using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSingleton : MonoBehaviour
{
    public static GameObject player;
    void Start()
    {
        if (player == null){
            player = GameObject.FindGameObjectWithTag("Player");
            Debug.Log(player.name);
        }
        else {
            Debug.Log("Created");
        }
    }
    public static void ChosenType(GameObject type){
        player = type;
    }
}
