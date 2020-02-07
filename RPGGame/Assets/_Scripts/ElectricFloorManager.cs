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
    private SpriteRenderer redIndicator;

    void Start()
    {
        wireTiles = GameObject.FindGameObjectsWithTag("Tiles");
        redIndicator = GameObject.Find("Red Indicator").GetComponent<SpriteRenderer>();
        StartCoroutine(setTilesOnline(red));
        changeTiles(red,wireTiles);
        setTilesOnline(red);
    }
    
    public void changeTiles(Color colour, params GameObject[] tiles){
        foreach (GameObject tile in tiles){   
            tile.GetComponent<ElectricTile>().colour = colour;
        }
    }

    public IEnumerator setTilesOnline(Color colour){
        yield return new WaitForSeconds(2);
        foreach (GameObject tile in wireTiles){
            if (tile.GetComponent<ElectricTile>().colour == colour){
                tile.GetComponent<BoxCollider2D>().enabled = true;
            }
            else{
                tile.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        redIndicator.color += new Color (0, 0, 0, 0.5f);
    }
}
