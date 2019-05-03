using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkatingSounds : MonoBehaviour {

    public PlayerMovement_2 player;

    float currentSpeed;

    public AudioSource skateSound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        currentSpeed = new Vector2(player.controller.velocity.x, player.controller.velocity.z).magnitude;
        if (player.controller.isGrounded && player.gm.playerHealth > 0 && player.gm.gameOn)
        {
            skateSound.volume = (currentSpeed / 20);
        }
        else
        {
            skateSound.volume = 0;
        }
	}
}
