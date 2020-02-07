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
        wireTiles[0].GetComponent<SpriteRenderer>().color = red;
    }
    
    public void changeTiles(Color colour, params GameObject[] tiles){
        foreach (GameObject tile in tiles){   
            tile.GetComponent<SpriteRenderer>().color = colour;
        }
    }

    public void setTilesOnline(Color colour){
        foreach (GameObject tile in wireTiles){
            if (tile.GetComponent<SpriteRenderer>().color == colour){
                tile.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }
}
