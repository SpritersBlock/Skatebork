using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour {

    PlayerMovement_2 player;
    GameObject target;
    GameObject child;
    Rigidbody rb;

    bool isHeld;
    public bool beingFired;
    public float throwForce;
    public float upBoost;

	// Use this for initialization
	void Awake () {
        player = FindObjectOfType<PlayerMovement_2>();
        target = GameObject.FindGameObjectWithTag("Respawn");
        child = gameObject.transform.GetChild(0).gameObject;
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (isHeld)
        {
            transform.position = target.transform.position;
            transform.rotation = target.transform.rotation;
            if (Input.GetMouseButtonDown(0))
            {
                //Destroy(gameObject);
                Fire();
            }
        }
	}

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //GameObject clone;
            //clone = Instantiate(child, target.transform);
            //clone.transform.position = Vector3.zero;
            //clone.GetComponent<Rigidbody>().isKinematic = true;
            if (!beingFired && !player.hasFood)
            {
                player.hasFood = true;
                isHeld = true;
                rb.isKinematic = true;
            }
            //Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (beingFired)
        {
            if (collision.gameObject.tag == "Trolley" || collision.gameObject.tag == "Boss" || collision.gameObject.tag == "Obstacle")
            {
                Destroy(gameObject);
            }
        }
    }

    void Fire()
    {
        beingFired = true;
        isHeld = false;
        rb.isKinematic = false;
        player.hasFood = false;
        Vector3 aimForce;
        aimForce = Camera.main.transform.parent.forward * throwForce;
        if (player.controller.isGrounded)
        {
            aimForce.y += upBoost;
        } else
        {
            aimForce.y = Camera.main.transform.parent.forward.y;
        }
        rb.velocity = aimForce;

    }
}
