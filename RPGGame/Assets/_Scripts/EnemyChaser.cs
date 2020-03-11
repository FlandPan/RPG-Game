using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaser : MonoBehaviour
{
    public float moveSpeed;
    private GameObject _player;

    private Vector2 _movement;
    private Vector2 _playerPosition;
    private Vector2 _position;


    void Start()
    {
        _player = PlayerSingleton.player;
    }


    void FixedUpdate()
    {
        _playerPosition = _player.transform.position;
        _position = this.transform.position;

        Vector2 direction = _playerPosition-_position;
        direction.Normalize();

        this.transform.Translate(direction*Time.deltaTime*moveSpeed);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject == PlayerSingleton.player){
            GameEvents.current.playerGetsDamaged(10);
        }
    }
}
