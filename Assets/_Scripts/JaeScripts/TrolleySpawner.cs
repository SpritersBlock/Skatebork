using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrolleySpawner : MonoBehaviour {

    public GameObject trolleyPrefab;
    public Vector3 spawnPos;
    public GameObject spawnPFX;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.U))
        {
            //SpawnTrolleyBoy();
        }
	}

    public void SpawnTrolleyBoy()
    {
        GameObject trolleyClone;
        GameObject poofClone;
        trolleyClone = Instantiate(trolleyPrefab, transform);
        trolleyClone.transform.position = spawnPos;
        poofClone = Instantiate(spawnPFX, null);
        poofClone.transform.position = trolleyClone.transform.position;
    }
}
