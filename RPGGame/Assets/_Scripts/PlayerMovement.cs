using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator animator;
    public float upperBound;
    public float lowerBound;
    public float leftBound;
    public float rightBound;
    public GameObject projectilePrefab;
    public GameObject horizontalProjectilePrefab;
    
    public float bulletForce = 15f;

    Vector3 movement;


    void Update()
    {
        //Inputs
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        if (Input.GetKeyDown(KeyCode.Space)){
            Blink(movement);
        }
        if(Input.GetButtonDown("Fire1"))
        {
            Debug.Log("fire@");
            Shoot();
        }
    }

    void FixedUpdate()
    {
        transform.Translate(moveSpeed * movement * Time.fixedDeltaTime);
    }

    private void Blink(Vector2 direction){
        direction *= 3*Vector2.SqrMagnitude(direction);
        Vector2 newPos = transform.position + new Vector3(direction.x, direction.y);
        if (newPos.x < leftBound)
            newPos.x = leftBound;
        if (newPos.y < lowerBound)
            newPos.y = lowerBound;
        if (newPos.x > rightBound)
            newPos.x = rightBound;
        if (newPos.y > upperBound)
            newPos.y = upperBound;
        transform.position = newPos;
    }
    void Shoot(){
        
        if(movement.y == -1)
        {
            GameObject projectile = Instantiate(projectilePrefab);
            projectile.transform.position = transform.position;
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.AddForce(new Vector3(0,-1,0) * bulletForce,ForceMode.Impulse);
        }
        else if (movement.y == 1)
        {
            GameObject projectile = Instantiate(projectilePrefab);
            projectile.transform.position = transform.position;
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            SpriteRenderer temp = projectile.GetComponent<SpriteRenderer>();
            temp.flipX = true;
            temp.flipY = true;
            rb.AddForce(new Vector3(0,1,0) * bulletForce,ForceMode.Impulse);
        }
        else if (movement.x == 1)
        {
            GameObject projectile = Instantiate(horizontalProjectilePrefab);
            projectile.transform.position = transform.position;
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            SpriteRenderer temp = projectile.GetComponent<SpriteRenderer>();
            temp.flipY = true;
            temp.flipX = true;
            rb.AddForce(new Vector3(1,0,0) * bulletForce,ForceMode.Impulse);
        }
        else if (movement.x == -1)
        {
            GameObject projectile = Instantiate(horizontalProjectilePrefab);
            projectile.transform.position = transform.position;
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.AddForce(new Vector3(-1,0,0) * bulletForce,ForceMode.Impulse);
        }
        else
        {
            GameObject projectile = Instantiate(projectilePrefab);
            projectile.transform.position = transform.position;
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.AddForce(new Vector3(0,-1,0) * bulletForce,ForceMode.Impulse);
        }
    }
}
