using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossScript : MonoBehaviour
{
    public GameObject hero;
    public GameObject addProj;
    public GameObject minusProj;
    public GameObject multProj;
    public GameObject divProj;
    private Vector3 _aimVector;
    private Vector3 _aimRoundVector;
    private int _roundCount = 0;
    private int chooser = 3;
    private bool counterClockwise = false;
    private GameObject projectilePrefab;
    private int projectileCounter=0;
    private int hardMode = 1;
    private float timeForAttack =0f;
    private float timeForStanceChange = 8f;
    private float timeForRandomAttack = 0f;
    private GameObject [] projectiles = new GameObject [4];


    // Update is called once per frame
    void Start() {


        projectiles[0] = addProj;
        projectiles[1] = minusProj;
        projectiles[2] = multProj;
        projectiles[3] = divProj;
        projectilePrefab = projectiles[projectileCounter];
        hero = PlayerSingleton.player;

    }
    void Update()
    {
        if(BossHits.getHP()>25)
        {
            /***************ATTACK PATTERN 1 RANDOM PROJECTILES**************************/
            if(timeForRandomAttack<=0)
                {
                    randomDirectProjectile();
                    timeForRandomAttack = 0.25f;
                }
            else
                {
                    timeForRandomAttack -= Time.deltaTime;
                }
        }
        else
        {
            /***************ATTACK PATTERN 2 SPIRAL PROJECTILES**************************/
            timeForStanceChange -= Time.deltaTime;
            if(timeForStanceChange<=0)
            {
                projectileCounter++;
                if(projectileCounter==4)
                {
                    projectileCounter=0;
                }
                projectilePrefab=projectiles[projectileCounter];
                chooser = Random.Range(1,4);
                if(Random.Range(0,2)==1)
                {
                    counterClockwise = true;
                }
                else
                {
                    counterClockwise = false;
                }
                timeForStanceChange=8f;
            }
            timeForAttack -= Time.deltaTime;
            if(timeForAttack<=0)
            {
                spiralProjectiles(chooser,counterClockwise);
                timeForAttack = 0.06f;
            }
        }
        
    }
    float unitVector(Vector3 num)
    {
        return Mathf.Sqrt(num.x*num.x+num.y*num.y+num.z+num.z);
    }
    void spiralProjectiles(int rings, bool counterClockwise)
    {
        if(counterClockwise)
        _aimRoundVector = new Vector3(Mathf.Sin(_roundCount),Mathf.Cos(_roundCount),0);

        else
        _aimRoundVector = new Vector3(Mathf.Cos(_roundCount),Mathf.Sin(_roundCount),0);

        for(int x =0; x<rings;x++)
        {
            _roundCount++;
        }
        GameObject circleProj = Instantiate(projectilePrefab);
        circleProj.transform.position = transform.position;
        Rigidbody2D rb = circleProj.GetComponent<Rigidbody2D>();
        rb.AddForce(_aimRoundVector*4*hardMode,ForceMode2D.Impulse);
    }
    void randomDirectProjectile()
    {
        _aimVector = hero.transform.position - transform.position;
        for(int x =0; x<3; x++)
        {
            if(Random.Range(0,2)==0)
            {
            _aimVector.x = _aimVector.x + x*Random.Range(1,6);
            _aimVector.y = _aimVector.y + x*Random.Range(1,6);
            }
            else
            {
            _aimVector.x = _aimVector.x - x*Random.Range(1,6);
            _aimVector.y = _aimVector.y - x*Random.Range(1,6);
            }
            GameObject directProj = Instantiate(projectiles[Random.Range(0,4)]);
            directProj.transform.position = transform.position;
            Rigidbody2D rb = directProj.GetComponent<Rigidbody2D>();
            rb.AddForce((_aimVector/unitVector(_aimVector))*Random.Range(2,4),ForceMode2D.Impulse);
        }
        _aimVector =  transform.position - hero.transform.position;
        for(int x =0; x<3; x++)
        {
            if(Random.Range(0,2)==0)
            {
            _aimVector.x = _aimVector.x + x*Random.Range(1,6);
            _aimVector.y = _aimVector.y + x*Random.Range(1,6);
            }
            else
            {
            _aimVector.x = _aimVector.x - x*Random.Range(1,6);
            _aimVector.y = _aimVector.y - x*Random.Range(1,6);
            }
            GameObject directProj = Instantiate(projectiles[Random.Range(0,4)]);
            directProj.transform.position = transform.position;
            Rigidbody2D rb = directProj.GetComponent<Rigidbody2D>();
            rb.AddForce((_aimVector/unitVector(_aimVector))*Random.Range(2,4),ForceMode2D.Impulse);
        }
       
    }
}
