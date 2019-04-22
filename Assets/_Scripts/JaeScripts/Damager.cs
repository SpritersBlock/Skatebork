using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour {

    private Rigidbody rb;
    PlayerMovement_2 player;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        player = FindObjectOfType<PlayerMovement_2>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.TakeDamage();
        }
    }
}
