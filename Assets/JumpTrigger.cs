using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour {

    public PlayerMovement player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            //player.rb.velocity = new Vector3(player.rb.velocity.x, 0, player.rb.velocity.z);
            //player.Bounce();
        }
    }
}
