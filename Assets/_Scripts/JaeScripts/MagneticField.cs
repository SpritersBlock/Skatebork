using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticField : MonoBehaviour {

    public GameObject bossMagnet;
    public GameObject playerMagnet;
    public ItemController itemCont;
    public float bossForceFactor;
    public float bossAttractRadius;
    public float playerForceFactor;
    public float playerAttractRadius;
    Rigidbody rb;
    PlayerMovement_2 player;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        bossMagnet = FindObjectOfType<BossController>().gameObject;
        playerMagnet = FindObjectOfType<PlayerMovement_2>().gameObject;
        player = playerMagnet.GetComponent<PlayerMovement_2>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (bossMagnet != null)
        {
            if (Vector3.Distance(transform.position, bossMagnet.transform.position) < bossAttractRadius && itemCont.beingFired)
            {
                //rb.AddForce((bossMagnet.transform.position - transform.position) * bossForceFactor * Time.smoothDeltaTime);
            }
        }
        
        if (playerMagnet != null)
        {
            if (Vector3.Distance(transform.position, playerMagnet.transform.position) < playerAttractRadius && !itemCont.beingFired && !player.hasFood)
            {
                rb.AddForce((playerMagnet.transform.position - transform.position) * playerForceFactor * Time.smoothDeltaTime);
            }
        }
    }
}
