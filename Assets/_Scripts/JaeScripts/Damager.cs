using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour {

    private Rigidbody rb;
    PlayerMovement_2 player;
    JaeGameManager gm;
    TrolleyBoyController trolley;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        player = FindObjectOfType<PlayerMovement_2>();
        gm = FindObjectOfType<JaeGameManager>();
        trolley = GetComponent<TrolleyBoyController>();
        if (trolley == null)
        {
            return;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "PlayerHurt")
        {
            if (!player.invincible && !trolley.stunned)
            {
                player.TakeDamage();
                gm.CameraShake();
                FindObjectOfType<AudioPlayer>().Play("Punch");
            }
        }
    }
}
