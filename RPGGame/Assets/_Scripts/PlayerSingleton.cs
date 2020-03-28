using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSingleton : MonoBehaviour
{
    public static GameObject player;
    public void Awake()
    {
        if (player == null){
            player = GameObject.FindGameObjectWithTag("Player");
        }
        else {
            Debug.Log("Created");
        }
    }
    public static void ChosenType(GameObject type){
        player = type;
    }
}
