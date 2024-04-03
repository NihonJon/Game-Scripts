using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;
 
    
    void Update()
    {
        //Gets the postions of x and y and stores it in the vector2
        movement.x = Input.GetAxisRaw("Horizontal"); 
        movement.y = Input.GetAxisRaw("Vertical");

        //changes the floats of Hor and Ver for the animator 
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {   
        //moves the player using the vector2 var  (Time.fixedDeltaTime makes it smooth depending on computer fps)
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    

    }
}
