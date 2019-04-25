using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour {

    public NavMeshAgent agent;

    public Transform targetTransform;

    private CameraShake cameraShake;

    public int bossHealth;

    void Start () {
        agent = GetComponent<NavMeshAgent>();
        cameraShake = FindObjectOfType<CameraShake>();
    }
	
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {

    }

    public void BossHit()
    {
        StartCoroutine(cameraShake.Shake(.15f, .4f));
        bossHealth--;
    }
}
