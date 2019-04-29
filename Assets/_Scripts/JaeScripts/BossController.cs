using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour {

    public NavMeshAgent agent;
    public BossHealthDisplayer bhd;

    public Transform targetTransform;

    private CameraShake cameraShake;

    public int bossHealth;

    //public Vector2 xBounds;
    //public Vector2 yBounds;

    public Transform[] waypointArray;

    float refreshTime;
    public float refreshMin;
    public float refreshMax;

    void Start () {
        agent = GetComponent<NavMeshAgent>();
        cameraShake = FindObjectOfType<CameraShake>();
        StartCoroutine("RefreshWaypoint");
    }
	
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {

    }

    void RandomTime()
    {
        refreshTime = Random.Range(refreshMin, refreshMax);
    }

    IEnumerator RefreshWaypoint()
    {
        RandomTime();
        agent.SetDestination(waypointArray[Random.Range(0, waypointArray.Length)].position);
        float lastTime = Time.realtimeSinceStartup;
        float timer = 0.0f;

        while (timer < refreshTime)
        {
            timer += (Time.realtimeSinceStartup - lastTime);
            lastTime = Time.realtimeSinceStartup;
            yield return null;
        }

        if (timer >= refreshTime)
        {
            StartCoroutine("RefreshWaypoint");
            //print("Reset");
            yield return null;
        }
    }

    public void BossHit()
    {
        StartCoroutine(cameraShake.Shake(.15f, .4f));
        bossHealth--;
        bhd.UpdateHealthText(bossHealth);
        if (bossHealth <= 0)
        {
            BossDie();
        }
    }

    public void BossDie()
    {
        Destroy(gameObject);
    }
}
