using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject projectilePrefab;    
    public GameObject firePrefab;
    public GameObject boltPrefab;
    public GameObject boomerangPrefab;

    public float bulletForce = 15f;
    public int weaponChoice = 0;
    private float _shootAttSpd = 0;
    public float _maxShootSpd = 0.75f;
    private float _burnAttSpd = 0;
    public float _maxBurnSpd = 1f;
    private float _boltAttSpd = 0;
    public float _maxBoltSpd = 0.25f;
    private bool _inputEnabled;
    private static bool _boltUnlocked;
    private static bool _boomUnlocked;
    
    void Start()
    {
        GameEvents.current.OnPlayerDeath += DisableInput;
        _inputEnabled = true;
    }
    public void DisableInput(){
        _inputEnabled = false;
        _boltUnlocked = false;
        _boomUnlocked = false;
    }
    public static void BoltUnlocked(int ind){
        _boltUnlocked = true;
    }
    public static void BoomUnlocked(int ind){
        _boomUnlocked = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (_inputEnabled){
            //Weapon Switching
            if (Input.GetKeyDown(KeyCode.Alpha3) && _boomUnlocked){
                weaponChoice = 3;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && _boltUnlocked){
                weaponChoice = 2;
            }
            if (Input.GetKeyDown(KeyCode.Alpha1) && this.gameObject.name == "Girl Player"){
                weaponChoice = 1;
            }
            if (Input.GetKeyDown(KeyCode.Alpha0) && this.gameObject.name == "Player"){
                weaponChoice = 0;
            }

            //Weapon cooldown
            if(_shootAttSpd>0)
            {
            _shootAttSpd -= Time.deltaTime;
            }
            if(_burnAttSpd>0)
            {
            _burnAttSpd-= Time.deltaTime;
            }
            if(_boltAttSpd > 0){
                _boltAttSpd -= Time.deltaTime;
            }
            string shootDirection = "";
            bool pressed = false;
            //Left shoot
            if (Input.GetKeyDown(KeyCode.J)){
                shootDirection = "left";
                pressed = true;
            }
            //Down shoot
            if (Input.GetKeyDown(KeyCode.K)){
                shootDirection = "down";
                pressed = true;
            }
            //Up shoot
            if (Input.GetKeyDown(KeyCode.I)){
                shootDirection = "up";
                pressed = true;
            }
            //Right shoot
            if (Input.GetKeyDown(KeyCode.L)){
                shootDirection = "right";
                pressed = true;
            }
            if (pressed){
                if (weaponChoice == 0 && _shootAttSpd <= 0){
                    Shoot(shootDirection);
                    _shootAttSpd = _maxShootSpd;
                }
                else if (weaponChoice == 1 && _burnAttSpd <= 0){
                    Burn(shootDirection);
                    _burnAttSpd = _maxBurnSpd;
                }
                else if (weaponChoice == 2 && _boltAttSpd <= 0){
                    Bolt(shootDirection);
                    _boltAttSpd = _maxBoltSpd;
                }
                else if (weaponChoice == 3 && GameObject.Find("boomerang(Clone)")==null){
                    Boomerang(shootDirection);
                }
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
    public void Boomerang(string direction)
    {
        Quaternion rotate = new Quaternion();
        Vector3 side = new Vector3();
        
         switch (direction)
        {
            case "up":
                rotate = Quaternion.Euler(0,0,90);
                side = Vector3.up;
                break;
            case "down":
                rotate = Quaternion.Euler(0,0,270);
                side = Vector3.down;
                break;
            case "left":
                rotate = Quaternion.Euler(0,0,180);
                side = Vector3.left;
                break;
            case "right":
                rotate = Quaternion.Euler(0,0,0);
                side = Vector3.right;
                break;
        }
        GameObject firedProj = Instantiate(boomerangPrefab,transform.position + (side)*2,rotate);
        firedProj.GetComponent<Rigidbody2D>().AddForce(side*bulletForce,ForceMode2D.Impulse);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == ("boomerang(Clone)")){
            Destroy(other.gameObject);
        }
    }
}
