using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ElectricFloorManager : MonoBehaviour
{
    private Tilemap _floor;
    public Color red = Color.red;
    public Color black;
    public Color blue;

    void Start()
    {
        _floor = GameObject.Find("Tilemap").GetComponent<Tilemap>();

    }
}
