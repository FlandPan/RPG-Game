using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangScript : MonoBehaviour
{
    GameObject hero;

    private bool returning = false;
    // Start is called before the first frame update
    void Start()
    {
        hero = PlayerSingleton.player;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > hero.GetComponent<PlayerMovement>().upperBound || transform.position.y < hero.GetComponent<PlayerMovement>().lowerBound || transform.position.x < hero.GetComponent<PlayerMovement>().leftBound || transform.position.x > hero.GetComponent<PlayerMovement>().rightBound)
        {
            returning = true;
        }
        transform.Rotate(new Vector3(0,0,360) * Time.deltaTime);
        if(returning == true)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3 (0,0,0);
            Vector3 aim = Vector3.Normalize((hero.transform.position - transform.position));
            GetComponent<Rigidbody2D>().AddForce(aim*15f,ForceMode2D.Impulse);
        }
    }
     
    
}
