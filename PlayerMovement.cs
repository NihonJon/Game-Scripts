using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    //variables for shooting 
    public GameObject bulletPrefab;
    public float bulletSpeed;
    private float lastFire;
    public float fireDelay;
 
    
    void Update()
    {
        //Gets the postions of x and y and stores it in the vector2
        movement.x = Input.GetAxisRaw("Horizontal"); 
        movement.y = Input.GetAxisRaw("Vertical");

        //changes the floats of Hor and Ver for the animator 
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        //stores var for the arrow key input that was changed in the build settings
        float shootHor = Input.GetAxis("ShootHorizontal");
        float shootVert = Input.GetAxis("ShootVertical");


        //runs the shoot method if conditions are met
        if((shootHor != 0 || shootVert != 0) && Time.time > lastFire + fireDelay){
            Shoot(shootHor,shootVert);
            lastFire = Time.time;

        }
    }

    void FixedUpdate()
    {   
        //moves the player using the vector2 var  (Time.fixedDeltaTime makes it smooth depending on computer fps)
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    

    }

    void Shoot(float x, float y)
    {
        //creates object at players position, changes gravity and adds a velocity 
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
        bullet.AddComponent<Rigidbody2D>().gravityScale = 0;
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector3 (
            (x < 0) ? Mathf.Floor(x) * bulletSpeed : Mathf.Ceil(x) * bulletSpeed, 
            (y < 0) ? Mathf.Floor(y) * bulletSpeed : Mathf.Ceil(y) * bulletSpeed,
            0
        );
    }
}
