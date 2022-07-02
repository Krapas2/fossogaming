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
		); //predicting player's position with velocity (clientside only, not client prediction)
		Vector3 desiredPosition = player.transform.position + speedOffset; // moving camera ahead of player's predicted position
		Vector3 smoothedPosition = (desiredPosition-transform.position).magnitude < 0.01 ? 
            Vector3.Lerp (transform.position, desiredPosition, .75f) : 
            desiredPosition; //if desired position is close to transform, not lerping to avoid jittering due to imprecision
		transform.position = smoothedPosition;
    }
}