﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OOBKill : MonoBehaviour {

    public float yLevelKill;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y <= yLevelKill)
        {
            Destroy(gameObject);
        }
        if (transform.position.y <= -3)
        {
            transform.position += new Vector3 (0,3,0);
        }
	}
}