using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyPrefab;
    private bool check = false;

    // Update is called once per frame
    void Update()
    {
        if(check == false && Mathf.Floor(Time.time) %5 == 0)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.transform.position = new Vector3(-10,-5,0);
            check = true;
        }
        else if(check == true &&Mathf.Floor(Time.time) %5 == 1)
        {
            check = false;
        }
    }
}
