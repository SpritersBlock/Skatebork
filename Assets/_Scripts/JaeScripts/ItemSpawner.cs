using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class ItemSpawner : MonoBehaviour {

    public GameObject[] itemArray;
    public float itemSpawnSpeed;
    public float itemLaunchSpeed;
    public JaeGameManager gm;
    public TutorialManager tutMan;

    bool firstSpawn = true;

    public AnalyticsTracker itemsSpawned;
    public AnalyticsTracker itemMaxMet;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnItem(Transform trolleyTransform)
    {
        if (gm.foodCount < gm.foodMax)
        {
            if (firstSpawn)
            {
                firstSpawn = false;
                tutMan.TurnOffJump();
            }
            GameObject itemClone;
            itemClone = Instantiate(itemArray[Random.Range(0, itemArray.Length)], trolleyTransform.position, trolleyTransform.rotation);
            Rigidbody rb = itemClone.GetComponent<Rigidbody>();
            rb.velocity += (Vector3.up * itemSpawnSpeed);
            rb.velocity += new Vector3(Random.Range(-itemLaunchSpeed, itemLaunchSpeed) * itemSpawnSpeed, 0, Random.Range(-itemLaunchSpeed, itemLaunchSpeed) * itemSpawnSpeed);
            gm.foodCount++;
            itemsSpawned.TriggerEvent();
        }
    }
}
