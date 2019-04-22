using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour {

    public NavMeshAgent agent;

    public Transform targetTransform;
    
    void Start () {
        agent = GetComponent<NavMeshAgent>();
    }
	
	void Update () {
		
	}
}
