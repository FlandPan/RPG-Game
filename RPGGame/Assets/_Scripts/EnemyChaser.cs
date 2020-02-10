using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaser : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    private Rigidbody2D _player;

    private Vector2 _movement;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _movement.y = (_player.position.y-rb.position.y);
        _movement.x = (_player.position.x-rb.position.x);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + _movement * moveSpeed * Time.fixedDeltaTime);
    }
}
