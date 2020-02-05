using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaser : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Rigidbody2D player;

    private Vector2 _movement;

    

    // Update is called once per frame
    void Update()
    {
        _movement.y = (player.position.y-rb.position.y);
        _movement.x = (player.position.x-rb.position.x);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + _movement * moveSpeed * Time.fixedDeltaTime);
    }
}
