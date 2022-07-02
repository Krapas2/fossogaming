using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : NetworkBehaviour
{

    public float hp; //maximum HP

    public string localPlayer; // layer for the local player
    public string foreignPlayer; // layer for the foreign players

    [HideInInspector]
    public float curHP; // current hp

    [HideInInspector]
    public PlayerMovement movement;

    void Start()
    {
        movement = GetComponent<PlayerMovement>();
        curHP = hp;

        //handle differences between local and foreign players
        if(isLocalPlayer){
            Camera mainCam = Camera.main;
            CameraController connCam = FindObjectOfType<CameraController>();

            //change cameras when connect
            connCam.player = this;
            connCam.gameObject.SetActive(true);
            mainCam.enabled = false;
            mainCam.gameObject.SetActive(false);
            
            gameObject.layer = LayerMask.NameToLayer(localPlayer);
        }
        else{
            gameObject.layer = LayerMask.NameToLayer(foreignPlayer);
        }
    }
    void Update ()
	{
		if (curHP <= 0) {
			Die ();
		} else if (curHP > hp){
            curHP = hp;
        }
	}

    void Die ()
	{
		Destroy(gameObject);
	}
}
