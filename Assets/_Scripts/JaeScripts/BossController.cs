using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Analytics;

public class BossController : MonoBehaviour {

    public NavMeshAgent agent;
    public BossHealthDisplayer bhd;
    public TutorialManager tutMan;
    public TrolleySpawner trSpawn;

    public Transform targetTransform;

    private CameraShake cameraShake;

    public int bossHealth;
    bool fullHealth = true;
    public GameObject bossClone;

    //public Vector2 xBounds;
    //public Vector2 yBounds;

    public Transform[] waypointArray;

    float refreshTime;
    public float refreshMin;
    public float refreshMax;

    public AnalyticsTracker bossHitAT;
    public AnalyticsTracker bossDieAT;

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
            timer += (Time.realtimeSinceStartup - lastTime) * Time.timeScale;
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
        if (fullHealth)
        {
            fullHealth = false;
        }
        StartCoroutine(cameraShake.Shake(.15f, .4f));
        bossHealth--;
        bhd.UpdateHealthText(bossHealth);
        FindObjectOfType<AudioPlayer>().Play("Squeal");
        bossHitAT.TriggerEvent();
        if (bossHealth <= 0)
        {
            BossDie();
        }
        if (!fullHealth)
        {
            tutMan.TurnOffThrow();
        }
        if (bossHealth == 9 || bossHealth == 7 || bossHealth == 5 || bossHealth == 3 || bossHealth == 2 || bossHealth == 1)
        {
            trSpawn.SpawnTrolleyBoy();
            Debug.Log("NEWSPAWN");
        }
    }

    public void BossDie()
    {
        StartCoroutine("BossDeathProcess");
        bossDieAT.TriggerEvent();
    }

    public IEnumerator BossDeathProcess()
    {
        agent.speed = 0;

        bossClone = Instantiate(bossClone, null);
        bossClone.transform.position = transform.position;
        bossClone.transform.rotation = transform.rotation;
        //bossClone.GetComponent<Rigidbody>().AddForce(new Vector3(5, 5, 5), ForceMode.Impulse);
        
        //yield return new WaitForSeconds(1);
        Destroy(gameObject);
        yield return null;
    }
}
