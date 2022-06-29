using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{

    public float movementSpeed = 5;

    private void Movement()
    {
        if(isLocalPlayer){
            Vector3 move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

            transform.position += move * movementSpeed * Time.deltaTime;
        }
    }

    void Update()
    {
        Movement();
    }

}
