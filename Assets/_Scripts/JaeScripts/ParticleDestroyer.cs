using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroyer : MonoBehaviour {

    public ParticleSystem particleSys;

	// Use this for initialization
	void Start () {
        particleSys = GetComponent<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () {
		if (!particleSys.IsAlive())
        {
            Destroy(gameObject);
        }
	}
}
