﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class ItemSpawner : MonoBehaviour {

    public GameObject[] itemArray;
    public float itemSpawnSpeed;
    public JaeGameManager gm;

    public AnalyticsTracker itemsSpawned;
    public AnalyticsTracker itemMaxMet;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnItem(Transform trolleyTransform)
    {
        if (gm.foodCount < gm.foodMax)
        {
            GameObject itemClone;
            itemClone = Instantiate(itemArray[Random.Range(0, itemArray.Length)], trolleyTransform.position, trolleyTransform.rotation);
            Rigidbody rb = itemClone.GetComponent<Rigidbody>();
            rb.velocity += (Vector3.up * itemSpawnSpeed);
            gm.foodCount++;
            itemsSpawned.TriggerEvent();
        }
    }
}