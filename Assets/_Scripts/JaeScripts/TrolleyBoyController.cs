using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrolleyBoyController : MonoBehaviour {

    public NavMeshAgent agent;

    public Transform targetTransform;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        Invoke("LockOn", 1f);
    }
	
	// Update is called once per frame
	void Update () {
        LockOn();
	}

    void LockOn()
    {
        //Debug.Log("A");
        agent.SetDestination(targetTransform.position);
        //Invoke("LockOn", 0.5f);
    }
}
