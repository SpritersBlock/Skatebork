using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {

    public GameObject[] itemArray;
    public float itemSpawnSpeed;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnItem(Transform trolleyTransform)
    {
        GameObject itemClone;
        itemClone = Instantiate(itemArray[Random.Range(0, itemArray.Length)], trolleyTransform.position, trolleyTransform.rotation);
        Rigidbody rb = itemClone.GetComponent<Rigidbody>();
        rb.velocity += (Vector3.up * itemSpawnSpeed);
    }
}
