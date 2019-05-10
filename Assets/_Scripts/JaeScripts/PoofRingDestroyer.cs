using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoofRingDestroyer : MonoBehaviour {

    public ParticleSystem poofRing;

    // Use this for initialization
    void Start () {
        poofRing = GetComponentInChildren<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!poofRing.IsAlive())
        {
            Destroy(gameObject);
        }
    }
}
