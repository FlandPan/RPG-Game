using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject projectilePrefab;    
    public GameObject firePrefab;
    public GameObject boltPrefab;

    public float bulletForce = 15f;
    public int weaponChoice = 0;
    private int _shootAttSpd = 0;
    private int _maxShootSpd = 100;
    private int _burnAttSpd = 0;
    private int _maxBurnSpd = 100;
    private int _boltAttSpd = 0;
    private int _maxBoltSpd = 1;
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
            if(_boltAttSpd != 0){
                _boltAttSpd --;
            }
            //Left shoot
            if (Input.GetKeyDown(KeyCode.J)){
                switch(weaponChoice){
                    case 0:
                        Shoot("left");
                        _shootAttSpd = _maxShootSpd;
                        break;
                    case 1:
                        Burn("left");
                        _burnAttSpd = _maxBurnSpd;
                        break;
                }

            }
            //Down shoot
            if (Input.GetKeyDown(KeyCode.K)){

            }
            //Up shoot
            if (Input.GetKeyDown(KeyCode.I)){

            }
            //Right shoot
            if (Input.GetKeyDown(KeyCode.L)){

            }
            /////////////////////////////Bolt Shooting///////////////////////////////////////
            /////////////////////////////Projectile Shooting/////////////////////////////////
                if(weaponChoice == 0 && Input.GetKeyDown(KeyCode.J) && _shootAttSpd == 0)
                {
                    Shoot("left");
                    _shootAttSpd = 100;
                }
                else if(weaponChoice == 0 && Input.GetKeyDown(KeyCode.I) && _shootAttSpd == 0)
                {
                    Shoot("up");
                    _shootAttSpd = 100;
                }
                else if(weaponChoice == 0 && Input.GetKeyDown(KeyCode.L) && _shootAttSpd == 0)
                {
                    Shoot("right");
                    _shootAttSpd = 100;
                }
                else if(weaponChoice == 0 && Input.GetKeyDown(KeyCode.K) && _shootAttSpd == 0)
                {
                    Shoot("down");
                    _shootAttSpd = 100;
                }
            //////////////////////////////Fire Shooting//////////////////////////////////////
                if(weaponChoice == 1 && Input.GetKeyDown(KeyCode.J) && _burnAttSpd == 0)
                {
                    Burn("left");
                    _burnAttSpd = 100;
                }
                else if(weaponChoice == 1 && Input.GetKeyDown(KeyCode.I) && _burnAttSpd == 0)
                {
                    Burn("up");
                    _burnAttSpd = 100;
                }
                else if(weaponChoice == 1 && Input.GetKeyDown(KeyCode.L) && _burnAttSpd == 0)
                {
                    Burn("right");
                    _burnAttSpd = 100;
                }
                else if(weaponChoice == 1 && Input.GetKeyDown(KeyCode.K) && _burnAttSpd == 0)
                {
                    Burn("down");
                    _burnAttSpd = 100;
                }
        }
    }
    void Shoot(string direction){
            PlayerMovement pm = GetComponent<PlayerMovement>();
            if(direction == "left")
            {
                Quaternion rotate = Quaternion.Euler(0,0,-90);
                GameObject projectile = Instantiate(projectilePrefab,transform.position, rotate);
                Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                rb.AddForce((new Vector3(-1,0,0)) * bulletForce,ForceMode2D.Impulse);
            }
            else if(direction == "right")
            {
                Quaternion rotate = Quaternion.Euler(0,0,90);
                GameObject projectile = Instantiate(projectilePrefab,transform.position, rotate);
                Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                rb.AddForce((new Vector3(1,0,0)) * bulletForce,ForceMode2D.Impulse);
            }
            else if(direction == "up")
            {
                Quaternion rotate = Quaternion.Euler(0,0,0);
                GameObject projectile = Instantiate(projectilePrefab,transform.position, rotate);
                Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                rb.AddForce((new Vector3(0,1,0)) * bulletForce,ForceMode2D.Impulse);
            }
            else
            {
                Quaternion rotate = Quaternion.Euler(0,0,180);
                GameObject projectile = Instantiate(projectilePrefab,transform.position, rotate);
                Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                rb.AddForce((new Vector3(0,-1,0)) * bulletForce,ForceMode2D.Impulse);
            }
    }
    void Burn(string direction)
    {
        PlayerMovement pm = GetComponent<PlayerMovement>();
        GameObject fire = Instantiate(firePrefab);
        if(direction == "left")
        fire.transform.position = transform.position + new Vector3(-2,0,0);
        else if(direction == "right")
        fire.transform.position = transform.position + new Vector3(2,0,0);
        else if(direction == "up")
        fire.transform.position = transform.position + new Vector3(0,2,0);
        else
        fire.transform.position = transform.position + new Vector3(0,-2,0);
    }
    public void setWeaponChoice(int x)
    {
        weaponChoice = x;
    }
    public void Bolt(string direction){
        Quaternion rotate = new Quaternion();
        Vector2 side = new Vector2();
        switch (direction)
        {
            case "up":
                rotate = Quaternion.Euler(0,0,0);
                side = Vector2.up;
                break;
            case "down":
                rotate = Quaternion.Euler(0,0,180);
                side = Vector2.down;
                break;
            case "left":
                rotate = Quaternion.Euler(0,0,90);
                side = Vector2.left;
                break;
            case "right":
                rotate = Quaternion.Euler(0,0,270);
                side = Vector2.right;
                break;
        }
        GameObject firedProj = Instantiate(boltPrefab,transform.position,rotate);
        firedProj.GetComponent<Rigidbody2D>().AddForce(side*bulletForce,ForceMode2D.Impulse);
    }
}
