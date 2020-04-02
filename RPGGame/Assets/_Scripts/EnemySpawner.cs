using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyPrefab;
    private bool check = false;
    private int maxEnemies = 10;
    private int enemyCount =0;
    public bool done;

    // Update is called once per frame
    void Update()
    {
        if(maxEnemies!=enemyCount && check == false && Mathf.Floor(Time.time) %3 == 0)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.transform.position = new Vector3(Random.Range(-10,10),Random.Range(-5,5),0);
            
            check = true;
            enemyCount++;
        }
        else if(check == true &&Mathf.Floor(Time.time) %3 == 1)
        {
            check = false;
        }
        done = maxEnemies == enemyCount;
    }
}
