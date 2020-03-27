using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class ElectricFloorManager : MonoBehaviour
{
    private ElectricTile[] _leftTiles;
    private ElectricTile[] _middleTiles;
    private ElectricTile[] _rightTiles;
    private Color _red = Color.red;
    private Color _green = Color.green;
    private Color _blue = Color.blue;
    private SpriteRenderer redIndicator;
    private int tileTracker = 0;
    public GameObject winUI;

    void Awake()
    {
        _leftTiles = GameObject.Find("Left Wires").GetComponentsInChildren<ElectricTile>();
        _middleTiles = GameObject.Find("Middle Wires").GetComponentsInChildren<ElectricTile>();
        _rightTiles = GameObject.Find("Right Wires").GetComponentsInChildren<ElectricTile>();
        Invoke("AssignTiles", 2);
    }
    void Update()
    {
        bool check = CheckEnemies();
        if (check && this.gameObject.GetComponent<EnemySpawner>().done){
            winUI.SetActive(true);
        }
    }
    private void ChangeColors(Color color, ElectricTile[] tiles, bool active){
        foreach (ElectricTile tile in tiles)
        {
            tile.gameObject.GetComponent<BoxCollider2D>().enabled = active;
            tile.mainColor = color;
            tile.colour = color;
        }
    }
    private void AssignTiles(){
        Color color = _red;
        ElectricTile[] tiles = _leftTiles;

        switch (tileTracker)
        {
            case 0:
                color = _red;
                tiles = _leftTiles;
                tileTracker = 1;
                ChangeColors(Color.white, _rightTiles, false);
                break;
            case 1:
                color = _green;
                tiles = _middleTiles;
                tileTracker = 2;
                ChangeColors(Color.white, _leftTiles, false);
                break;
            case 2:
                color = _blue;
                tiles = _rightTiles;
                tileTracker = 0;
                ChangeColors(Color.white, _middleTiles, false);
                break;
        }
        ChangeColors(color,tiles, true);
        Invoke("AssignTiles", 2);
    }
    public void ReturnHome(){
        SceneManager.LoadScene(0);
    }
    private bool CheckEnemies(){
        return GameObject.FindGameObjectsWithTag("Enemy").Length == 0;
    }
}