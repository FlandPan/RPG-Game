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
    public GameObject firePrefab;

    public float bulletForce = 15f;
    public static int weaponChoice=0;

    Vector3 movement;

    private int shootAttSpd =0;
    private int burnAttSpd =0;

    void Update()
    {
        if(shootAttSpd!=0)
        {
        shootAttSpd--;
        }
        if(burnAttSpd!=0)
        {
        burnAttSpd--;
        }
        //Inputs
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetKeyDown(KeyCode.Space)){
            Blink(movement);
        }
        if(weaponChoice == 0 && Input.GetButtonDown("Fire1") && shootAttSpd == 0)
        {
            Shoot();
            shootAttSpd = 50;
        }
        if(weaponChoice == 1 && Input.GetButtonDown("Fire1") && burnAttSpd == 0)
        {
            Burn();
            burnAttSpd = 100;
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
        Quaternion newRotation = new Quaternion();
        float rotation = Mathf.Abs(movement.x)*(180 + movement.x * -90) + movement.y*(90 + movement.y*90);
        newRotation = Quaternion.Euler(0,0,rotation);
        GameObject projectile = Instantiate(projectilePrefab,transform.position,newRotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.Scale(new Vector3(1,1,0),movement) * bulletForce,ForceMode.Impulse);
    }
        void Burn()
        {
            GameObject fire = Instantiate(firePrefab);
            Vector3 newPos = new Vector3(2,2,0);
            newPos = Vector3.Scale(newPos,movement);
            fire.transform.position = transform.position + newPos;
        }
        public void setWeaponChoice(int x)
        {
            weaponChoice = x;
        }
    
}
