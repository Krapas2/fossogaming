using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : NetworkBehaviour
{


    
    public Player player;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        if(player)
            FollowPlayer();
    }

    void FollowPlayer()
    {
        Vector3 speedOffset = new Vector3 (
			player.movement.rb.velocity.x * .05f,
			player.movement.rb.velocity.y * .05f,
			-10
		);
		Vector3 desiredPosition = player.transform.position + speedOffset;
		Vector3 smoothedPosition = Vector3.Lerp (transform.position, desiredPosition, .75f);
		transform.position = smoothedPosition;
    }
}
