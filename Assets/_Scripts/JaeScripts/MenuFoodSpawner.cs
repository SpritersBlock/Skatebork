using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFoodSpawner : MonoBehaviour {

    public GameObject[] itemArray;
    public float itemSpawnSpeed;
    public float itemLaunchSpeed;

    float timer;
    public float timerMax;

    // Use this for initialization
    void Start () {
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        
        
        if (timer < timerMax)
        {
            timer += Time.deltaTime;
        }

        if (timer >= timerMax)
        {
            SpawnItem(transform);
            timer = 0;
        }
	}

    public void SpawnItem(Transform spawnTransform)
    {
        GameObject itemClone;
        itemClone = Instantiate(itemArray[Random.Range(0, itemArray.Length)], spawnTransform.position, spawnTransform.rotation);
        Rigidbody rb = itemClone.GetComponent<Rigidbody>();
        rb.velocity += (Vector3.up * itemSpawnSpeed);
        rb.velocity += new Vector3(Random.Range(-itemLaunchSpeed, itemLaunchSpeed) * itemSpawnSpeed, 0, Random.Range(-itemLaunchSpeed, itemLaunchSpeed) * itemSpawnSpeed);
    }
}
