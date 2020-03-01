using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaser : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    private Rigidbody2D _player;

    private Vector2 _movement;
    public float forceFactor;

    void Start()
    {
        _player = PlayerSingleton.player.GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        float x = _player.position.x-rb.position.x;
        float y = _player.position.y-rb.position.y;
        Vector2 unitDirection = Vector2.ClampMagnitude(new Vector2(x,y), 1);
        rb.velocity = new Vector2(x,y);
        //rb.AddForce(unitDirection * moveSpeed * Time.fixedDeltaTime,ForceMode2D.Force);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player"){
            GameEvents.current.playerGetsDamaged(5);
            Vector2 direction = new Vector2(_player.position.x-rb.position.x,_player.position.y-rb.position.y);
            //rb.AddForce(direction*-forceFactor,ForceMode2D.Impulse);
            rb.position = _player.position-direction;
        }
    }
}
