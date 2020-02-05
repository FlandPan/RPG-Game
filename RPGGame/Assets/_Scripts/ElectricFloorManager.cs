using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ElectricFloorManager : MonoBehaviour
{
    public GameObject[] wireTiles;
    public Color red = Color.red;
    public Color black;
    public Color blue;

    void Start()
    {
        wireTiles = GameObject.FindGameObjectsWithTag("Tiles");
        wireTiles[1].GetComponent<SpriteRenderer>().color = red;
        wireTiles[3].GetComponent<SpriteRenderer>().color = red;
        wireTiles[2].GetComponent<SpriteRenderer>().color = red;
        wireTiles[0].GetComponent<SpriteRenderer>().color = red;

    }
    
    public void changeTiles( Color colour, params GameObject[] tiles){
        foreach (GameObject tile in tiles){   
            
        }
    }
}
