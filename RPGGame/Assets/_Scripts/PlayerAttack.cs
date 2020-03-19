using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject projectilePrefab;    
    public GameObject firePrefab;

    public float bulletForce = 15f;
    public static int weaponChoice = 0;
    private int _shootAttSpd = 0;
    private int _burnAttSpd = 0;
    private bool _inputEnabled;
    
    void Start()
    {
        GameEvents.current.OnPlayerDeath += DisableInput;
        _inputEnabled = true;
    }
    public void DisableInput(){
        _inputEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_inputEnabled){
            if(_shootAttSpd!=0)
            {
            _shootAttSpd--;
            }
            if(_burnAttSpd!=0)
            {
            _burnAttSpd--;
            }
            
            if(weaponChoice == 0 && Input.GetKeyDown(KeyCode.Mouse0) && _shootAttSpd == 0)
            {
                Shoot();
                _shootAttSpd = 50;
            }
            if(weaponChoice == 1 && Input.GetKeyDown(KeyCode.Mouse0) && _burnAttSpd == 0)
            {
                Burn();
                _burnAttSpd = 100;
            }
        }
    }
    void Shoot(){
            PlayerMovement pm = GetComponent<PlayerMovement>();
            Quaternion newRotation = new Quaternion();
            float rotation = Mathf.Abs(pm.movement.x)*(180 + pm.movement.x * -90) + pm.movement.y*(90 + pm.movement.y*90);
            newRotation = Quaternion.Euler(0,0,rotation);
            GameObject projectile = Instantiate(projectilePrefab,transform.position,newRotation);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            Vector3 temp = (pm.movement.x ==0 && pm.movement.y ==0)?new Vector3(0,-1,0):pm.movement;
            rb.AddForce(Vector3.Scale(new Vector3(1,1,0),temp) * bulletForce,ForceMode2D.Impulse);
    }
        void Burn()
        {
            PlayerMovement pm = GetComponent<PlayerMovement>();
            GameObject fire = Instantiate(firePrefab);
            Vector3 newPos = new Vector3(2,2,0);
            Vector3 temp = (pm.movement.x ==0 && pm.movement.y ==0)?new Vector3(0,-1,0):pm.movement;
            newPos = Vector3.Scale(newPos,temp);
            fire.transform.position = transform.position + newPos;
        }
        public void setWeaponChoice(int x)
        {
            weaponChoice = x;
        }
}
