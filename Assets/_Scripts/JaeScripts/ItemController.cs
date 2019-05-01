﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour {

    PlayerMovement_2 player;
    GameObject target;
    GameObject child;
    [HideInInspector]
    public Rigidbody rb;
    FoodLauncher launcher;
    public GameObject pfxPrefab;
    public JaeGameManager gm;
    TrailRenderer trail;

    [HideInInspector]
    public bool isHeld;
    public bool beingFired;
    public float throwForce;
    public float upBoost;

	// Use this for initialization
	void Awake () {
        player = FindObjectOfType<PlayerMovement_2>();
        target = GameObject.FindGameObjectWithTag("Respawn");
        child = gameObject.transform.GetChild(0).gameObject;
        rb = GetComponent<Rigidbody>();
        launcher = FindObjectOfType<FoodLauncher>();
        gm = FindObjectOfType<JaeGameManager>();
        trail = GetComponent<TrailRenderer>();
        trail.enabled = false;
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
            if (!beingFired && !player.hasFood)
            {
                player.hasFood = true;
                isHeld = true;
                //rb.useGravity = false;
                rb.isKinematic = true;
                FindObjectOfType<AudioPlayer>().Play("Pop");
            }
            //GameObject clone;
            //clone = Instantiate(child, target.transform);
            //clone.transform.position = Vector3.zero;
            //clone.GetComponent<Rigidbody>().isKinematic = true;
            //Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //print(collision.gameObject.name);
        if (beingFired)
        {
            if (collision.gameObject.tag == "Trolley" || collision.gameObject.tag == "Boss" || collision.gameObject.tag == "Obstacle")
            {
                FindObjectOfType<AudioPlayer>().Play("Splat");
                //Instantiate UNPARENTED PFX
                GameObject pfxClone;
                pfxClone = Instantiate(pfxPrefab);
                pfxClone.transform.position = transform.position;
                Destroy(gameObject);
                gm.foodCount--;
            }
            if (collision.gameObject.tag == "Boss")
            {
                FindObjectOfType<BossController>().BossHit();
            }
        }
    }

    void Fire()
    {
        beingFired = true;
        isHeld = false;
        trail.enabled = true;
        //rb.useGravity = false;
        rb.isKinematic = false;
        player.hasFood = false;
        Vector3 aimForce;
        aimForce = Camera.main.transform.parent.forward * throwForce;
        aimForce += new Vector3(0, upBoost, 0);
        rb.velocity = aimForce;
        FindObjectOfType<AudioPlayer>().Play("Throw");
        //launcher.Launch();
        //Destroy(gameObject);
    }
}
