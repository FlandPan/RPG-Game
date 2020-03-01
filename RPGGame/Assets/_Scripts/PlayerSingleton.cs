using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSingleton : MonoBehaviour
{
    public static GameObject player;
    void Awake()
    {
        if (player == null){
            player = GameObject.Find("Player");
        }
        else {
            Debug.Log("Created");
        }
    }
}
