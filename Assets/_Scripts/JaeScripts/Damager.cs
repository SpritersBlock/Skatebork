using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour {

    private Rigidbody rb;
    PlayerMovement_2 player;
    private CameraShake cameraShake;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        player = FindObjectOfType<PlayerMovement_2>();
        cameraShake = FindObjectOfType<CameraShake>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.TakeDamage();
            if (!player.invincible)
            {
                StartCoroutine(cameraShake.Shake(.15f, .4f));
            }
        }
    }
}
