using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator animator;


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
    }

    void FixedUpdate()
    {
        transform.Translate(moveSpeed * movement * Time.fixedDeltaTime);
    }

    private void Blink(Vector2 direction){
        direction *= 3*Vector2.SqrMagnitude(direction);
        Vector2 newPos = transform.position + new Vector3(direction.x, direction.y);
        if (newPos.x < -10)
            newPos.x = -11;
        if (newPos.y < -9)
            newPos.y = -9;
        if (newPos.x > 10)
            newPos.x = 10;
        if (newPos.y > 7)
            newPos.y = 7;
        transform.position = newPos;
    }
}
