using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ElectricTile : MonoBehaviour
{
    public Color mainColor;

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player"){
            colour = Color.yellow;
            GameEvents.current.playerGetsDamaged(10);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player"){
            colour = mainColor;
        }
    }

    public Color colour{
        get {
            return this.gameObject.GetComponent<SpriteRenderer>().color;
        }
        set {
            this.gameObject.GetComponent<SpriteRenderer>().color = value;
        }
    }
}