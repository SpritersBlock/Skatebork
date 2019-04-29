using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrolleyBoyController : MonoBehaviour {

    public NavMeshAgent agent;
    //private JaeGameManager gm;
    private Animator anim;

    public Transform targetTransform;

    public bool stunned;
    
    public GameObject[] itemArray;
    public float itemSpawnSpeed;

    void Start () {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        //gm = FindObjectOfType<JaeGameManager>();
    }
	
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
        GameObject itemClone;
        itemClone = Instantiate(itemArray[Random.Range(0, itemArray.Length)], transform.position, transform.rotation);
        Rigidbody rb = itemClone.GetComponent<Rigidbody>();
        rb.velocity += (Vector3.up * itemSpawnSpeed);
        //rb.velocity += new Vector3(Random.Range(-itemSpawnSpeed / 2, itemSpawnSpeed / 2), 0, Random.Range(-itemSpawnSpeed / 2, itemSpawnSpeed / 2));

        agent.speed = 0;
        stunned = true;
        anim.SetBool("Stunned", true);
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
            anim.SetBool("Stunned", false);
            yield return null;
        }
    }
}
