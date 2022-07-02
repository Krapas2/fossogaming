using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Player))]
public class PlayerMovement : NetworkBehaviour
{

    public float speed = 20f; // desired velocity
    public float acceleration = .005f; // rate of acceleration to input
    public float deceleration = .05f; // rate of acceleration to zero

    public LayerMask stopOnCollide;

    [HideInInspector]
    public Rigidbody2D  rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Movement();
    }
    
    private void Movement()
    {
        if(isLocalPlayer){
            Vector2 move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

            // lerp to desired velocity according to input
            rb.velocity = Vector2.Lerp(rb.velocity, move * speed, move.magnitude > 0f ? acceleration : deceleration); // use deceleration if no input
        }
    }

    void OnCollisienStay2d(Collision2D con)
    {
        if(stopOnCollide == (stopOnCollide | (1 << con.gameObject.layer ))){
            rb.velocity = Vector2.zero;
        }
    }
}