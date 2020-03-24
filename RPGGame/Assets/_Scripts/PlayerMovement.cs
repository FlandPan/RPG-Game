using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator animator;
    public float upperBound;
    public float lowerBound;
    public float leftBound;
    public float rightBound;
    public Vector3 movement;
    private bool _inputEnabled;
    public bool eventSet;

    void Awake()
    {
        _inputEnabled = true;
        SetEvent();
    }
    public void SetEvent(){
        eventSet = true;
        GameEvents.current.OnPlayerDeath += Test;
    }
    public void Test(){
        Debug.Log("Testing");
    }
    public void SetBounds(params int[] bounds){
        upperBound = bounds[0];
        lowerBound = bounds[1];
        leftBound = bounds[2];
        rightBound = bounds[3];
    }

    public void DisableInputs(){
        _inputEnabled = false;
        movement = Vector2.zero;
    }

    void Update()
    {
        //Inputs
        if (_inputEnabled){
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetKeyDown(KeyCode.Space) && _inputEnabled){
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
    
    
}
