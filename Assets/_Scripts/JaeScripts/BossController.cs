using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour {

    public NavMeshAgent agent;

    public Transform targetTransform;

    private CameraShake cameraShake;

    void Start () {
        agent = GetComponent<NavMeshAgent>();
        cameraShake = FindObjectOfType<CameraShake>();
    }
	
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ItemController>() != null)
        {
            if (other.GetComponent<ItemController>().beingFired)
            {
                StartCoroutine(cameraShake.Shake(.15f, .4f));
            }
        }
    }
}
