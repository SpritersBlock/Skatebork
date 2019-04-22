using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrolleyBoyController : MonoBehaviour {

    public NavMeshAgent agent;

    public Transform targetTransform;

    public bool stunned;

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

    public IEnumerator Stun(float stunTime)
    {
        agent.speed = 0;
        stunned = true;
        // Animator code for squished enemy
        float lastTime = Time.realtimeSinceStartup;
        float timer = 0.0f;

        while (timer < stunTime)
        {
            timer += (Time.realtimeSinceStartup - lastTime);
            lastTime = Time.realtimeSinceStartup;
            yield return null;
        }

        if (timer >= stunTime)
        {
            agent.speed = 27;
            stunned = false;
            yield return null;
        }
    }
}
