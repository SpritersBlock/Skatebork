using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrolleyBoyController : MonoBehaviour {
    
    public NavMeshAgent agent;
    private JaeGameManager gm;
    private Animator anim;

    public PlayerMovement_2 player;
    public float distanceToPlayer;
    public float distanceToWaypoint;

    public Transform[] waypointArray;
    public Transform targetTransform;

    public bool stunned;
    float origSpeed;

    public ItemSpawner spawner;

    void Start () {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        gm = FindObjectOfType<JaeGameManager>();
        origSpeed = agent.speed;
        player = FindObjectOfType<PlayerMovement_2>();
        targetTransform = player.transform;
        spawner = FindObjectOfType<ItemSpawner>();
        GameObject[] wpGameObjects = GameObject.FindGameObjectsWithTag("TrolleyWP");
        for(int i = 0; i < waypointArray.Length; i++)
        {
            waypointArray[i] = wpGameObjects[i].transform;
        }
        if (gm.jumpTextOff)
        {
            GameObject.Find("JumpText").SetActive(false);
        }
    }
	
	void Update () {
        if (targetTransform != gm.finalTarget.transform)
        {
            if (Vector3.Distance(gameObject.transform.position, player.gameObject.transform.position) < distanceToPlayer)
            {
                if (targetTransform != player.transform)
                {
                    targetTransform = player.transform;
                }
            }
            else
            {
                if (targetTransform == player.transform)
                {
                    targetTransform = waypointArray[Random.Range(0, waypointArray.Length)];
                }
                if (Vector3.Distance(gameObject.transform.position, targetTransform.position) < distanceToWaypoint)
                {
                    targetTransform = waypointArray[Random.Range(0, waypointArray.Length)];
                }
            }
        }
        LockOn();

        if (!stunned && agent.speed < origSpeed)
        {
            agent.speed += 1f * Time.deltaTime;
        }
        if (agent.speed > origSpeed)
        {
            agent.speed = origSpeed;
        }
    }

    void LockOn()
    {
        //Debug.Log("A");
        agent.SetDestination(targetTransform.position);
        //Invoke("LockOn", 0.5f);
    }

    public void FoodStun()
    {
        agent.speed = 0;
    }

    public IEnumerator Stun(float stunTime)
    {
        bool warningOn = false;
        spawner.SpawnItem(transform);
        float timeBeforeActive;
        timeBeforeActive = (stunTime/6) * 5;
        
        agent.speed = 0;
        stunned = true;
        anim.SetBool("Stunned", true);
        // Animator code for squished enemy
        float lastTime = Time.realtimeSinceStartup;
        float timer = 0.0f;

        //Debug.Log("stunTime: " + stunTime + ", timeBeforeActive: " + timeBeforeActive);

        while (timer < timeBeforeActive)
        {
            timer += (Time.realtimeSinceStartup - lastTime) * Time.timeScale;
            lastTime = Time.realtimeSinceStartup;
            yield return null;
        }

        if (timer >= timeBeforeActive)
        {
            //print("Part A");
            if (!warningOn)
            {
                //print("Part B");
                anim.SetTrigger("WarnFlash");
                warningOn = true;
            }
        }

        while (timer < stunTime)
        {
            timer += (Time.realtimeSinceStartup - lastTime) * Time.timeScale;
            lastTime = Time.realtimeSinceStartup;
            yield return null;
        }

        if (timer >= stunTime)
        {
            //print("Part C");
            warningOn = false;
            agent.speed = origSpeed;
            stunned = false;
            anim.SetBool("Stunned", false);
            yield return null;
        }
    }
}
