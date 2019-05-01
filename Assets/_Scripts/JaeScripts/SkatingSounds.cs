using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkatingSounds : MonoBehaviour {

    public PlayerMovement_2 player;

    public AudioSource skateSound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (player.controller.isGrounded && Input.GetAxis("Vertical") != 0)
        {
            skateSound.volume = 0.7f;
        }
        else
        {
            skateSound.volume = 0;
        }
	}
}
