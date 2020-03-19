using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawn : MonoBehaviour
{
    void Awake()
    {
        if (SceneManager.GetActiveScene().name != "Hub"){
            Debug.Log("Test");
            GameObject player = PlayerSingleton.player;
            Debug.Log(player.name);
            Instantiate(player, new Vector3(0,0,0), new Quaternion());
        }
    }
}
