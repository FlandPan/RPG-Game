using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyPrefab;
    public int maxEnemies = 10;
    private bool _check = false;
    private int _enemyCount = 0;
    

    // Update is called once per frame
    void Update()
    {
        if(_check == false && Mathf.Floor(Time.time) %5 == 0 && maxEnemies != _enemyCount)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.transform.position = new Vector3(-10,-5,0);
            _check = true;
            _enemyCount++;
        }
        else if(_check == true &&Mathf.Floor(Time.time) %5 == 1)
        {
            _check = false;
        }
    }
}
