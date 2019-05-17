using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCloneDeath : MonoBehaviour {

    public PlayerMovement_2 player;
    Transform playerTr;
    Rigidbody rb;

	// Use this for initialization
	void Awake () {
        player = FindObjectOfType<PlayerMovement_2>();
        playerTr = player.transform;
        rb = GetComponent<Rigidbody>();
        SpawnPlayerClone();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnPlayerClone()
    {
        transform.position = playerTr.position;
        transform.rotation = playerTr.rotation;

        //rb.AddForce(new Vector3(0, -50, 0), ForceMode.Impulse);
        rb.AddExplosionForce(50, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), 10);
        player.gameObject.SetActive(false);
    }
}
