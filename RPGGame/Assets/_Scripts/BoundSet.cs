using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoundSet : MonoBehaviour
{

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Electric DLS"){
            GameObject player = PlayerSingleton.player;
            player.GetComponent<PlayerMovement>().SetBounds(6,-8,-10,10);
        }
        if (SceneManager.GetActiveScene().name == "Data and Algo"){
            GameObject player = PlayerSingleton.player;
            player.GetComponent<PlayerMovement>().SetBounds(10,-6,-18,6);
        }
        if (SceneManager.GetActiveScene().name == "Boss"){
            GameObject player = PlayerSingleton.player;
            player.GetComponent<PlayerMovement>().SetBounds(10,-6,-18,6);
        }
    }
}
